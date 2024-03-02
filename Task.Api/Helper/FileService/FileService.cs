//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Task.Api.Helper.FileService
//{
//    public class FileService : IFileService
//    {
//        private IWebHostEnvironment environment;
//        public FileService(IWebHostEnvironment env)
//        {
//            this.environment = env;
//        }
//        public string SaveImg(IFormFile imageFile)
//        {
//            try
//            {
//                var contentPath = this.environment.WebRootPath;
//                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
//                var path = Path.Combine(contentPath, "Uploads");
//                if (!Directory.Exists(path))
//                {
//                    Directory.CreateDirectory(path);
//                }

//                // Check the allowed extenstions
//                var ext = Path.GetExtension(imageFile.FileName);
//                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
//                if (!allowedExtensions.Contains(ext))
//                {
//                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
//                    return new  string(msg);
//                }
//                string uniqueString = Guid.NewGuid().ToString();
//                // we are trying to create a unique filename here
//                var newFileName = uniqueString + ext;
//                var fileWithPath = Path.Combine(path, newFileName);
//                var stream = new FileStream(fileWithPath, FileMode.Create);
//                imageFile.CopyTo(stream);
//                stream.Close();
//                return new string(newFileName);
//            }
//            catch (Exception ex)
//            {
//                return new string("Error has occured");
//            }
//        }

//        public bool DeleteImage(string PictureUrl)
//        {
//            try
//            {
//                var wwwPath = this.environment.WebRootPath;
//                var path = Path.Combine(wwwPath, "Uploads\\", PictureUrl);
//                if (System.IO.File.Exists(path))
//                {
//                    System.IO.File.Delete(path);
//                    return true;
//                }
//                return false;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }   
//    }
//}
