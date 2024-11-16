using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Tags.Commands.CreateTagCommand
{
    public class CreateTagCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Response<int>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            Tag tag = _mapper.Map<Tag>(request);
            var result = await _tagRepository.CreateAsync(tag);
            if (result == null)
            {
                throw new ApiException("Error while creating tag", StatusCodes.Status500InternalServerError);
            }
            Response<int> response = new();
            response.Succeeded = true;
            response.Data = tag.Id;
            response.StatusCode = StatusCodes.Status201Created;
            return response;
        }
    }
}
