using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dtos;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Services
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;

        public ImageService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }
        public List<ImageUploadResult> Upload(List<IFormFile> files)
        {
            List<ImageUploadResult> results = new List<ImageUploadResult>();
            foreach(var file in files)
            {
                Stream stream = file.OpenReadStream();

                var uploadParams = new ImageUploadParams()
                {
                    Folder = "nash",
                    UseFilename = true,
                    UniqueFilename = true,
                    Overwrite = true,
                    File = new FileDescription(file.FileName, stream)
                };
                ImageUploadResult result = cloudinary.Upload(uploadParams);
                results.Add(result);
            }
            return results;
        }
    }
}
