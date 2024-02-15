using CSharpFunctionalExtensions;
using xFood.Infrastructure;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API.Photos.Commands.Create
{
    public class CreatePhotoHandler : ICommandHandler<CreatePhotoRequest, Result<CreatePhotoResponse>>
    {
        private readonly XFoodContext _context;
        public CreatePhotoHandler(XFoodContext context)
        {
            _context = context;
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
                string filePath = Path.Combine("C:\\Users\\user\\Desktop\\ESDP-2\\src\\XFood.Web\\wwwroot\\images\\appeals\\", "images", fileName);
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
