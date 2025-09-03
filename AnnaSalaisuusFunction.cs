using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;

namespace Funktio072;

public class AnnaSalaisuusFunction
{
    private readonly IConfiguration _configuration;

    public AnnaSalaisuusFunction(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // GET /api/AnnaSalaisuus
    [Function("AnnaSalaisuus")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "AnnaSalaisuus")]
        HttpRequestData req)
    {
        var arvo = _configuration["SALAISUUS"];

        var res = req.CreateResponse(HttpStatusCode.OK);
        res.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        await res.WriteStringAsync(arvo ?? "(SALAISUUS ei ole asetettu)");
        return res;
    }
}
