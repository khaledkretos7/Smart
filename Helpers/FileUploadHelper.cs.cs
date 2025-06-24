using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartCity.Helpers
{
    public static class FileUploadHelper
    {
        public static async Task<string> UploadFileAsync(IFormFile file, string uploadPath)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            // أنشئ المسار لو مش موجود
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            // اسم الملف الجديد (unique)
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(uploadPath, uniqueFileName);

            // رفع الملف
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // رجع اسم الملف بعد الرفع
            return uniqueFileName;
        }

        public static void DeleteFile(string uploadPath, string fileName)
        {
            var fullPath = Path.Combine(uploadPath, fileName);

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
