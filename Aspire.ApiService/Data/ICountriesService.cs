using Aspire.ApiService.Model;

namespace Aspire.ApiService.Data
{
    public interface ICountriesService
    {
        Task<IEnumerable<Country>> GetTestObjList();
    }
}