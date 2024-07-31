using Aspire.Shared.Models;

namespace Aspire.ApiService.Data
{
    public interface ICountriesData
    {
        Task<IEnumerable<CountriesModel>> Countries_Get();
    }
}