using Microsoft.AspNetCore.Http;

namespace Task.Service.ProductService
{
    public static class DocumentSettings
    {
        //Upload File
        public static string UploadFile(IFormFile file, string folderName)
        {
            //1. Get Located Folder Path 
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);

            //2. Get File Name And Make It Unique
            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            //3. Fet File Path
            var filePath = Path.Combine(folderPath, fileName);

            //4. 
            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;

        }

        //Delete File
        public static void DeleteFile(string folderName, string fileName)
        {
            // Construct the full file path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName, fileName);

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // If the file exists, delete it
                File.Delete(filePath);
            }
        }
    }
}
