using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.CriticalFactor.Create;
using XFoodBlazor.Web.Client.Services.CriticalFactor.Delete;
using XFoodBlazor.Web.Client.Services.CriticalFactor.GetList;
using XFoodBlazor.Web.Client.Services.CriticalFactor.Update;

namespace XFoodBlazor.Web.Client.Services.CriticalFactor
{
    public interface ICriticalFactorService
    {
        Task<GetListCriticalFactorResponse> GetCriticalFactors(GetListCriticalFactorRequest criticalFactorModel);
        Task<CreateCriticalFactorResponse> Create(CreateCriticalFactorRequest criticalFactorModel);
        Task<UpdateCriticalFactorResponse> Update(UpdateCriticalFactorRequest criticalFactorModel);
        Task<DeleteCriticalFactorResponse> Delete(DeleteCriticalFactorRequest criticalFactorModel);
    }
    public class CriticalFactorService : ICriticalFactorService
    {
        private readonly HttpClient _httpClient;
        public CriticalFactorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetListCriticalFactorResponse> GetCriticalFactors(GetListCriticalFactorRequest criticalFactorModel)
        {
            var result = await _httpClient.GetAsync("criticalFactor/list");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetListCriticalFactorResponse>();
                return response;
            }
            return new GetListCriticalFactorResponse(null);
        }

        public async Task<CreateCriticalFactorResponse> Create(CreateCriticalFactorRequest criticalFactorModel)
        {
            var result = await _httpClient.PostAsJsonAsync("criticalFactor", criticalFactorModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreateCriticalFactorResponse>();
                return response;
            }
            return new CreateCriticalFactorResponse(false);
        }
        public async Task<UpdateCriticalFactorResponse> Update(UpdateCriticalFactorRequest criticalFactorModel)
        {
            Console.WriteLine("1");
            var result = await _httpClient.PutAsJsonAsync($"criticalFactor/{criticalFactorModel.Id}", criticalFactorModel);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("2");
                var response = await result.Content.ReadFromJsonAsync<UpdateCriticalFactorResponse>();
                return response;
            }
            Console.WriteLine("3");
            return new UpdateCriticalFactorResponse(false);
        }
        public async Task<DeleteCriticalFactorResponse> Delete(DeleteCriticalFactorRequest criticalFactorModel)
        {
            var result = await _httpClient.DeleteAsync($"criticalFactor/{criticalFactorModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<DeleteCriticalFactorResponse>();   
                return response;
            }
            return new DeleteCriticalFactorResponse(false);
        }
    }
}
