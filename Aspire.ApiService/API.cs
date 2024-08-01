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
        private static async Task<IResult> GetCountries(ICountriesService data)
        {
            try
            {
                return Results.Ok(await data.GetTestObjList());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
