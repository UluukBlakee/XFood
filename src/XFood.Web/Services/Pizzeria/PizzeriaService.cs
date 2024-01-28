using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.Pizzeria.Create;
using XFoodBlazor.Web.Client.Services.Pizzeria.GetList;
using XFoodBlazor.Web.Client.Services.Pizzeria.GetPizzeria;

namespace XFoodBlazor.Web.Client.Services.Pizzeria
{
    public interface IPizzeriaService
    {
        Task<GetListPizzeriaResponse> GetListPizzeria(GetListPizzeriaRequest pizzeriaModel);
        Task<GetPizzeriaResponse> GetPizzeria(GetPizzeriaRequest pizzeriaModel);
        Task<CreatePizzeriaResponse> CreatePizzeria(CreatePizzeriaRequest pizzeriaModel);
    }

    public class PizzeriaService : IPizzeriaService
    {
        private readonly HttpClient _httpClient;

        public PizzeriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetListPizzeriaResponse> GetListPizzeria(GetListPizzeriaRequest pizzeriaModel)
        {
            var result = await _httpClient.GetAsync("pizzeria/list");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetListPizzeriaResponse>();
                return response;
            }
            return new GetListPizzeriaResponse(null);
        }

        public async Task<GetPizzeriaResponse> GetPizzeria(GetPizzeriaRequest pizzeriaModel)
        {
            var result = await _httpClient.GetAsync($"pizzeria/{pizzeriaModel.Id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<GetPizzeriaResponse>();
                return response;
            }
            return new GetPizzeriaResponse(null);
        }

        public async Task<CreatePizzeriaResponse> CreatePizzeria(CreatePizzeriaRequest pizzeriaModel)
        {
            var result = await _httpClient.PostAsJsonAsync("pizzeria", pizzeriaModel);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<CreatePizzeriaResponse>();
                return response;
            }

            return new CreatePizzeriaResponse(false, await result.Content.ReadAsStringAsync());
        }
    }
}
