using CSharpFunctionalExtensions;
using XFood.Data;
using xFood.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace XFood.API.Photos.Queries.GetListPhoto
{
    public class GetListPhotoHandler : ICommandHandler<GetListPhotoRequest, Result<GetListPhotoResponse>>
    {
        private readonly XFoodContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GetListPhotoHandler(XFoodContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Result<GetListPhotoResponse>> Handle(GetListPhotoRequest command, CancellationToken cancellationToken)
        {
            var photos = await _context.Photos.Where(p => p.AppealId == command.AppealId).ToListAsync();

            if (photos.Any())
            {
                List<string> photoDataList = new List<string>();

                foreach (var photo in photos)
                {
                    var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, photo.Url);
                    if (System.IO.File.Exists(filePath))
                    {
                        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        var byteArray = await ReadFully(fileStream);
                        var base64String = Convert.ToBase64String(byteArray);
                        var mimeType = GetMimeType(filePath);
                        var imageData = $"data:{mimeType};base64,{base64String}";

                        photoDataList.Add(imageData);
                    }
                }
                return new GetListPhotoResponse(photoDataList);
            }
            return new GetListPhotoResponse(null);
        }

        private async Task<byte[]> ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await input.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

        private string GetMimeType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
