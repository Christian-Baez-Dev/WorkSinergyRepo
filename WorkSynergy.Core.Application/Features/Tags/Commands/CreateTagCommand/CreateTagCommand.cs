using AutoMapper;
using MediatR;
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
            await _tagRepository.CreateAsync(tag);

            return new Response<int>();
        }
    }
}
