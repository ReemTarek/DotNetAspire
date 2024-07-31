using Aspire.Shared.Models;
using System.Net.Http;

namespace Aspire.Web
{
    public class CountriesAPIClient(HttpClient httpClient)
    {
        public async Task<List<CountriesModel>> GetCounteiesAsync()
        {

            return await httpClient.GetFromJsonAsync<List<CountriesModel>>("/Countries", default);

        }
    }


}
