using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSynergy.Core.Application.Helpers;

namespace WorkSynergy.Core.Application.Features.Contracts.Commands.DownloadDeliverable
{
    public class DownloadDeliverableCommand : IRequest<FileResult>
    {
        public string Path { get; set; }
    }

    public class DownloadDeliverableCommandHandler : IRequestHandler<DownloadDeliverableCommand, FileResult>
    {
        public async Task<FileResult> Handle(DownloadDeliverableCommand request, CancellationToken cancellationToken)
        {
            request.Path = UploadHelper.GetBasePath(request.Path);
            if (!File.Exists(request.Path))
            {
                throw new FileNotFoundException("El archivo no se encontró en el servidor.");
            }
            var fileBytes = await File.ReadAllBytesAsync(request.Path, cancellationToken);
            var contentType = "application/vnd.rar"; 
            return new FileContentResult(fileBytes, contentType)
            {
                FileDownloadName = request.Path.Split('/').Last(),  
            };
        }
    }

}
