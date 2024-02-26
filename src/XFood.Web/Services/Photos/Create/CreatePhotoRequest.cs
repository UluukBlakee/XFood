using Microsoft.AspNetCore.Http;

namespace XFoodBlazor.Web.Client.Services.Photos.Create
{
    public class CreatePhotoRequest
    {
        public List<IFormFile>? Photos { get; set; }
        public int AppealId { get; set; }
    }
}
