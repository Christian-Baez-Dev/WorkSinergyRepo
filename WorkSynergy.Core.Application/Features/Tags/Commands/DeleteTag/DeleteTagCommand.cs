using AutoMapper;
using MediatR;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;

        public DeleteTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<Response<int>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            response.Succeeded = true;
            var post = await _tagRepository.GetByIdAsync(request.Id);
            await _tagRepository.DeleteAsync(post);
            return response;
        }
    }
}
