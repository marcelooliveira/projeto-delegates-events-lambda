using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaBancariaController : ControllerBase
    {
        private readonly ILogger<ContaBancariaController> _logger;

        public ContaBancariaController(ILogger<ContaBancariaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetContaBancaria")]
        public ContaBancaria Get()
        {
            return new ContaBancaria { Saldo = 1275.00m };
        }
    }
}