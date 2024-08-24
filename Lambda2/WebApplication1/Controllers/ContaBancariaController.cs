using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaBancariaController : ControllerBase
    {
        private readonly ILogger<ContaBancariaController> _logger;
        private List<ContaCorrente> contasCorrentes = new List<ContaCorrente>
        {
            new ContaCorrente("001", "12345-6", 1500.75m, DateTime.Now.AddDays(-5)),
            new ContaCorrente("002", "23456-7", 2500.50m, DateTime.Now.AddDays(-10)),
            new ContaCorrente("003", "34567-8", 3200.00m, DateTime.Now.AddDays(-15)),
            new ContaCorrente("004", "45678-9", 4100.25m, DateTime.Now.AddDays(-20)),
            new ContaCorrente("005", "56789-0", 5200.00m, DateTime.Now.AddDays(-25)),
            new ContaCorrente("006", "67890-1", 6300.50m, DateTime.Now.AddDays(-30)),
            new ContaCorrente("007", "78901-2", 7400.75m, DateTime.Now.AddDays(-35)),
            new ContaCorrente("008", "89012-3", 8500.00m, DateTime.Now.AddDays(-40)),
            new ContaCorrente("009", "90123-4", 9600.25m, DateTime.Now.AddDays(-45)),
            new ContaCorrente("010", "01234-5", 10700.50m, DateTime.Now.AddDays(-50))
        };

        public ContaBancariaController(ILogger<ContaBancariaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{agencia}/{conta}")]
        public ActionResult<decimal> Get(string agencia, string conta)
        {
            var contaCorrente = contasCorrentes
                .Where(cc => cc.Agencia == agencia && cc.Conta == conta)
                .SingleOrDefault();

            if (contaCorrente == null)
            {
                return NotFound();
            }

            return contaCorrente.Saldo;
        }
    }
}