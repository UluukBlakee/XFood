using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Photos.Create;
using XFoodBlazor.Web.Client.Services.Photos.GetListPhoto;

namespace XFoodBlazor.Web.Client.Services.Photos
{
    public interface IPhotoService
    {
        Task<CreatePhotoResponse> Create(CreatePhotoRequest photoModel);
        Task<GetListPhotoResponse> GetList(GetListPhotoRequest photoModel);
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
            using var content = new MultipartFormDataContent();
            foreach (var file in photoModel.Photos)
            {
                content.Add(new StreamContent(file.OpenReadStream()), "Photos", file.Name);
            }
            content.Add(new StringContent(photoModel.AppealId.ToString()), "AppealId");
            var result = await _httpClient.PostAsync("photo", content);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreatePhotoResponse>();
                return response;
            }
            return new CreatePhotoResponse(false);
        }

        public async Task<GetListPhotoResponse> GetList(GetListPhotoRequest photoModel)
        {
            var result = await _httpClient.GetAsync($"photo/list/{photoModel.AppealId}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetListPhotoResponse>();
                return response;
            }
            return new GetListPhotoResponse(null);
        }
    }
}
