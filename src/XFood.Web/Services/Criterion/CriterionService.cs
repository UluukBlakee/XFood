using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Criterion.Create;
using XFoodBlazor.Web.Client.Services.Criterion.Delete;
using XFoodBlazor.Web.Client.Services.Criterion.Update;

namespace XFoodBlazor.Web.Client.Services.Criterion
{
    public interface ICriterionService
    {
        Task<CreateCriterionResponse> Create(CreateCriterionRequest criteriaModel);
        Task<DeleteCriterionResponse> Delete(DeleteCriterionRequest criteriaModel);
        Task<UpdateCriterionResponse> Update(UpdateCriterionRequest criteriaModel);
    }
    public class CriterionService : ICriterionService
    {
        private readonly HttpClient _httpClient;
        public CriterionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreateCriterionResponse> Create(CreateCriterionRequest criteriaModel)
        {
            var result = await _httpClient.PostAsJsonAsync("criterion", criteriaModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreateCriterionResponse>();
                return response;
            }
            return new CreateCriterionResponse(false);
        }

        public async Task<DeleteCriterionResponse> Delete(DeleteCriterionRequest criteriaModel)
        {
            var result = await _httpClient.DeleteAsync($"criterion/{criteriaModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<DeleteCriterionResponse>();
                return response;
            }
            return new DeleteCriterionResponse(false);
        }

        public async Task<UpdateCriterionResponse> Update(UpdateCriterionRequest criteriaModel)
        {
            Console.WriteLine("1");
            var result = await _httpClient.PutAsJsonAsync($"criterion/{criteriaModel.Id}", criteriaModel);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("2");
                var response = await result.Content.ReadFromJsonAsync<UpdateCriterionResponse>();
                return response;
            }
            Console.WriteLine("3");
            return new UpdateCriterionResponse(false);
        }
    }
}
