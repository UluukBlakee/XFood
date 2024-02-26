using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.Photos.Commands.Create
{
    using Microsoft.AspNetCore.Hosting;

    public class CreatePhotoHandler : ICommandHandler<CreatePhotoRequest, Result<CreatePhotoResponse>>
    {
        private readonly XFoodContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreatePhotoHandler(XFoodContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Result<CreatePhotoResponse>> Handle(CreatePhotoRequest command, CancellationToken cancellationToken)
        {
            if (command.Photos != null)
            {
                foreach (var photo in command.Photos)
                {
                    Photo newPhoto = new Photo()
                    {
                        AppealId = command.AppealId,
                        Url = await UploadPhoto(photo)
                    };
                    var result = await _context.AddAsync(newPhoto);
                    if (result.Entity == null)
                    {
                        return new CreatePhotoResponse(false);
                    }
                }
                await _context.SaveChangesAsync();
                return new CreatePhotoResponse(true);
            }
            else { return new CreatePhotoResponse(true); }
        }

        public async Task<string> UploadPhoto(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                string imagePath = $"/images/{fileName}";
                return imagePath;
            }
            return null;
        }
    }

}
