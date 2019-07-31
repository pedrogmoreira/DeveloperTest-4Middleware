using DeveloperTest.Domain.Models;
using DeveloperTest.Tools.Csv;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DeveloperTest.Services.Api.Controllers
{
    [EnableCors(origins: "https://localhost:44314", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        [HttpPost]
        public IHttpActionResult SalvarDados([FromBody] IEnumerable<Test> model)
        {
            CsvManager.WriteToFile(model);

            return Created("api/Test/", model);
        }

        [HttpGet]
        public IHttpActionResult LerDados()
        {
            return Ok(CsvManager.ReadFromFile());
        }
    }
}