using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.JobOffers.Commands.DeleteJobOffer
{
    public class DeleteJobOfferCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteJobOfferCommandHandler : IRequestHandler<DeleteJobOfferCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IJobOfferRepository _jobOfferRepository;

        public DeleteJobOfferCommandHandler(IMapper mapper, IJobOfferRepository jobOfferRepository)
        {
            _mapper = mapper;
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<Response<int>> Handle(DeleteJobOfferCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var ability = await _jobOfferRepository.GetByIdAsync(request.Id);
            if(ability == null)
            {
                throw new ApiException("Ability not found", StatusCodes.Status404NotFound);
            }
            await _jobOfferRepository.DeleteAsync(ability);
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status204NoContent;
            return response;
        }
    }
}
