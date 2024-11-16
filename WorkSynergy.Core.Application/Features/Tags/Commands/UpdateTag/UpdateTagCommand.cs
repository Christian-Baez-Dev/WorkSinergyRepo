using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;

        public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<Response<int>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var result = await _tagRepository.UpdateAsync(_mapper.Map<Tag>(request), request.Id);
            if (result == null)
            {
                throw new ApiException("Error while updating tag", StatusCodes.Status500InternalServerError);
            }
            response.Succeeded = true;
            response.Data = result.Id;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }
}
