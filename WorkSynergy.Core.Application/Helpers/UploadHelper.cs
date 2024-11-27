using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Enums.Upload;

namespace WorkSynergy.Core.Application.Helpers
{
    public static class UploadHelper
    {
        public static string UploadFile(IFormFile file, string id, string type, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return imagePath;
                }
            }
            if (!Enum.IsDefined(typeof(UploadEntities), type))
            {
                return "";
            }
            string basePath = $"/Images/{type}/{id}";

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

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

            if (isEditMode && imagePath != null)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }

        public static void DeleteFile(string id, string type)
        {
            if (Enum.IsDefined(typeof(UploadEntities), type))
            {

                string basePath = $"/Images/{type}/{id}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

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
