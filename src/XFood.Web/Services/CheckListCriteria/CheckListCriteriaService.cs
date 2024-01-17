using System.Net.Http.Json;
using XFoodBlazor.Web.Client.Services.CheckListCriteria.SetPoints;

namespace XFoodBlazor.Web.Client.Services.CheckListCriteria
{
    public interface ICheckListCriteriaService
    {
        Task<SetPointsResponse> SetPoints(SetPointsRequest criteriaModel);
    }
    public class CheckListCriteriaService : ICheckListCriteriaService
    {
        private readonly HttpClient _httpClient;
        public CheckListCriteriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SetPointsResponse> SetPoints(SetPointsRequest criteriaModel)
        {
            var result = await _httpClient.PostAsJsonAsync("checkListCriteria/setPoints", criteriaModel);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<SetPointsResponse>();
                return response;
            }
            return new SetPointsResponse(false);
        }
    }
}
