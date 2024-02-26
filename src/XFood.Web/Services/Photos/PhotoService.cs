using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Photos.Create;

namespace XFoodBlazor.Web.Client.Services.Photos
{
    public interface IPhotoService
    {
        Task<CreatePhotoResponse> Create(CreatePhotoRequest photoModel);
    }
    public class PhotoService : IPhotoService
    {
        private readonly HttpClient _httpClient;

        public PhotoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CreatePhotoResponse> Create(CreatePhotoRequest photoModel)
        {
            var result = await _httpClient.PostAsJsonAsync("photo", photoModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreatePhotoResponse>();
                return response;
            }
            return new CreatePhotoResponse(false);
        }
    }
}
