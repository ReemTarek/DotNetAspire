using Aspire.ApiService.Data;

namespace Aspire.ApiService
{
    public static class API
    {
        public static void ConfigureApi(this WebApplication app)
        {
            //Products
            app.MapGet("/Countries", GetCountries);
        }
        private static async Task<IResult> GetCountries(ICountriesData data)
        {
            try
            {
                return Results.Ok(await data.Countries_Get());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
