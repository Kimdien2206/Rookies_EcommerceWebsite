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
        public ImageUploadResult Upload(IFormFile file)
        {
            Stream stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = true,
                File = new FileDescription(file.FileName, stream)
            };
            return cloudinary.Upload(uploadParams);
        }
    }
}
