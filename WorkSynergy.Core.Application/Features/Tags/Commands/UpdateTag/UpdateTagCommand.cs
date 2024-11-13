using AutoMapper;
using MediatR;
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
            response.Succeeded = true;
            var result = _tagRepository.UpdateAsync(_mapper.Map<Tag>(request), request.Id);
            return response;
        }
    }
}
