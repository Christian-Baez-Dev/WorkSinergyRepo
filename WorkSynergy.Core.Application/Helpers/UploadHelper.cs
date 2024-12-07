using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Enums.Upload;

namespace WorkSynergy.Core.Application.Helpers
{
    public static class UploadHelper
    {
        public static string GetBasePath(string path)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), $"Files/{path}");
        }
        public static string UploadFile(IFormFile file, string id, string type, string entity, bool isEditMode = false, string filePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return filePath;
                }
            }
            if (!Enum.IsDefined(typeof(UploadEntities), entity) || !Enum.IsDefined(typeof(UploadTypes), type))
            {
                return "";
            }
            string basePath = $"{type}/{entity}/{id}";

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"Files{basePath}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode && filePath != null)
            {
                string[] oldImagePart = filePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }
        public static string GetDefaultPFP()
        {
            return $"{UploadTypes.Images}/Default/DefaultPFP.jpg";
        }
        public static void DeleteFile(string id, string type, string entity)
        {
            if (Enum.IsDefined(typeof(UploadEntities), type))
            {

                string basePath = $"/{type}/{entity}/{id}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"/Files/{basePath}");

                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new(path);

                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo folder in directory.GetDirectories())
                    {
                        folder.Delete(true);
                    }

                    Directory.Delete(path);
                }

            }
        }
      
    }
}
