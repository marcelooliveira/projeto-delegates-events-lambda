using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaBancariaController : ControllerBase
    {
        private readonly ILogger<ContaBancariaController> _logger;
        private List<ContaCorrente> contasCorrentes = new List<ContaCorrente>
        {
            new ContaCorrente("001", "12345-6", 1500.75m, new DateTime(2024, 1, 3)),
            new ContaCorrente("002", "23456-7", 2500.50m, new DateTime(2024, 3, 3)),
            new ContaCorrente("003", "34567-8", 3200.00m, new DateTime(2024, 3, 13)),
            new ContaCorrente("004", "45678-9", 4100.25m, new DateTime(2024, 4, 2)),
            new ContaCorrente("005", "56789-0", 5200.00m, new DateTime(2024, 2, 13)),
            new ContaCorrente("006", "67890-1", 6300.50m, new DateTime(2024, 1, 4)),
            new ContaCorrente("007", "78901-2", 7400.75m, new DateTime(2024, 5, 16)),
            new ContaCorrente("008", "89012-3", 8500.00m, new DateTime(2024, 7, 13)),
            new ContaCorrente("009", "90123-4", 9600.25m, new DateTime(2024, 2, 8)),
            new ContaCorrente("010", "01234-5", 10700.50m, new DateTime(2024, 7, 13))
        };

        private List<Transacao> transacoes = new List<Transacao>()
        {
            new Transacao("004", "45678-9", 'C', 381.10m, new DateTime(2024, 08, 03, 09, 30, 24)),
            new Transacao("009", "90123-4", 'C',  22.94m, new DateTime(2024, 08, 05, 18, 43, 25)),
            new Transacao("005", "56789-0", 'D', 681.73m, new DateTime(2024, 08, 07, 01, 55, 22)),
            new Transacao("006", "67890-1", 'C', 351.26m, new DateTime(2024, 08, 06, 21, 16, 14)),
            new Transacao("009", "90123-4", 'D',  87.70m, new DateTime(2024, 08, 07, 06, 11, 27)),
            new Transacao("003", "34567-8", 'D', 408.34m, new DateTime(2024, 08, 02, 06, 45, 10)),
            new Transacao("010", "01234-5", 'D', 661.62m, new DateTime(2024, 08, 01, 03, 30, 20)),
            new Transacao("003", "34567-8", 'D', 555.28m, new DateTime(2024, 08, 05, 03, 23, 50)),
            new Transacao("010", "01234-5", 'C', 808.37m, new DateTime(2024, 08, 05, 02, 14, 18)),
            new Transacao("008", "89012-3", 'D', 170.38m, new DateTime(2024, 08, 05, 21, 34, 34)),
            new Transacao("004", "45678-9", 'D', 332.90m, new DateTime(2024, 08, 01, 20, 39, 25)),
            new Transacao("005", "56789-0", 'C', 173.98m, new DateTime(2024, 08, 05, 13, 09, 55)),
            new Transacao("009", "90123-4", 'D', 471.38m, new DateTime(2024, 08, 05, 23, 47, 53)),
            new Transacao("009", "90123-4", 'D', 726.75m, new DateTime(2024, 08, 03, 14, 57, 15)),
            new Transacao("010", "01234-5", 'C',  28.25m, new DateTime(2024, 08, 08, 10, 26, 50)),
            new Transacao("003", "34567-8", 'D', 522.15m, new DateTime(2024, 08, 03, 07, 31, 58)),
            new Transacao("005", "56789-0", 'D', 459.00m, new DateTime(2024, 08, 08, 08, 26, 30)),
            new Transacao("009", "90123-4", 'C', 343.94m, new DateTime(2024, 08, 07, 17, 05, 29)),
            new Transacao("002", "23456-7", 'C', 980.64m, new DateTime(2024, 08, 02, 06, 59, 53)),
            new Transacao("002", "23456-7", 'C', 193.12m, new DateTime(2024, 08, 03, 10, 44, 48)),
            new Transacao("001", "12345-6", 'C', 576.72m, new DateTime(2024, 08, 06, 14, 47, 01)),
            new Transacao("007", "78901-2", 'C', 476.74m, new DateTime(2024, 08, 06, 01, 53, 26)),
            new Transacao("005", "56789-0", 'D', 425.53m, new DateTime(2024, 08, 02, 08, 28, 07)),
            new Transacao("009", "90123-4", 'C', 113.37m, new DateTime(2024, 08, 06, 12, 20, 02)),
            new Transacao("007", "78901-2", 'C', 576.22m, new DateTime(2024, 08, 02, 09, 57, 53)),
            new Transacao("003", "34567-8", 'C', 289.36m, new DateTime(2024, 08, 05, 22, 57, 39)),
            new Transacao("009", "90123-4", 'D', 319.00m, new DateTime(2024, 08, 03, 01, 16, 46)),
            new Transacao("004", "45678-9", 'D', 396.26m, new DateTime(2024, 08, 05, 07, 43, 31)),
            new Transacao("004", "45678-9", 'C', 829.56m, new DateTime(2024, 08, 06, 22, 42, 39)),
            new Transacao("003", "34567-8", 'D', 319.00m, new DateTime(2024, 08, 02, 20, 29, 43)),
            new Transacao("009", "90123-4", 'C', 440.19m, new DateTime(2024, 08, 06, 19, 55, 29)),
            new Transacao("007", "78901-2", 'C', 348.95m, new DateTime(2024, 08, 04, 21, 35, 47)),
            new Transacao("009", "90123-4", 'C',  83.51m, new DateTime(2024, 08, 01, 13, 50, 20)),
            new Transacao("001", "12345-6", 'D', 661.18m, new DateTime(2024, 08, 04, 04, 27, 02)),
            new Transacao("007", "78901-2", 'D',  81.77m, new DateTime(2024, 08, 07, 09, 47, 32)),
            new Transacao("003", "34567-8", 'C', 936.35m, new DateTime(2024, 08, 04, 01, 29, 18)),
            new Transacao("002", "23456-7", 'D', 557.83m, new DateTime(2024, 08, 08, 23, 31, 49)),
            new Transacao("010", "01234-5", 'C', 972.35m, new DateTime(2024, 08, 01, 12, 17, 18)),
            new Transacao("010", "01234-5", 'D', 167.89m, new DateTime(2024, 08, 01, 20, 38, 24)),
            new Transacao("010", "01234-5", 'C',  86.14m, new DateTime(2024, 08, 05, 07, 11, 26)),
            new Transacao("010", "01234-5", 'D', 998.69m, new DateTime(2024, 08, 04, 00, 39, 42)),
            new Transacao("007", "78901-2", 'C', 254.03m, new DateTime(2024, 08, 08, 18, 45, 01)),
            new Transacao("006", "67890-1", 'D', 790.46m, new DateTime(2024, 08, 03, 00, 24, 32)),
            new Transacao("004", "45678-9", 'D', 787.39m, new DateTime(2024, 08, 07, 17, 57, 04)),
            new Transacao("005", "56789-0", 'D', 586.22m, new DateTime(2024, 08, 01, 21, 42, 00)),
            new Transacao("005", "56789-0", 'D', 345.03m, new DateTime(2024, 08, 06, 10, 30, 37)),
            new Transacao("008", "89012-3", 'C', 596.28m, new DateTime(2024, 08, 01, 16, 11, 17)),
            new Transacao("008", "89012-3", 'D', 208.12m, new DateTime(2024, 08, 02, 10, 17, 46)),
            new Transacao("006", "67890-1", 'C', 882.75m, new DateTime(2024, 08, 08, 11, 27, 35)),
            new Transacao("004", "45678-9", 'C', 616.24m, new DateTime(2024, 08, 07, 10, 03, 37))
        };

        public ContaBancariaController(ILogger<ContaBancariaController> logger)
        {
            _logger = logger;
            var json = JsonConvert.SerializeObject(transacoes);
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

        [HttpPost]
        [Route("sacar/{agencia}/{conta}")]
        public ActionResult<string> Sacar(string agencia, string conta, [FromBody] decimal valor)
        {
            var contaCorrente = contasCorrentes
                .FirstOrDefault(cc => cc.Agencia == agencia && cc.Conta == conta);

            if (contaCorrente == null)
            {
                return NotFound("Conta não encontrada.");
            }

            if (valor > contaCorrente.Saldo)
            {
                return BadRequest("Saldo insuficiente.");
            }

            contaCorrente.Saldo -= valor;
            transacoes.Add(new Transacao(agencia, conta, 'D', valor, DateTime.Now));

            return Ok($"Saque de {valor:C} realizado com sucesso. Novo saldo: {contaCorrente.Saldo:C}");
        }

        [HttpPost]
        [Route("depositar/{agencia}/{conta}")]
        public ActionResult<string> Depositar(string agencia, string conta, [FromBody] decimal valor)
        {
            var contaCorrente = contasCorrentes
                .FirstOrDefault(cc => cc.Agencia == agencia && cc.Conta == conta);

            if (contaCorrente == null)
            {
                return NotFound("Conta não encontrada.");
            }

            contaCorrente.Saldo += valor;
            transacoes.Add(new Transacao(agencia, conta, 'C', valor, DateTime.Now));

            return Ok($"Depósito de {valor:C} realizado com sucesso. Novo saldo: {contaCorrente.Saldo:C}");
        }

        [HttpGet]
        [Route("extrato/{agencia}/{conta}")]
        public ActionResult<List<Transacao>> Extrato(string agencia, string conta)
        {
            var contaCorrente = contasCorrentes
                .FirstOrDefault(cc => cc.Agencia == agencia && cc.Conta == conta);

            if (contaCorrente == null)
            {
                return NotFound("Conta não encontrada.");
            }

            var extrato = transacoes
                .Where(t => t.Agencia == agencia && t.Conta == conta)
                .OrderByDescending(t => t.DataRegistro)
                .ToList();

            return Ok(extrato);
        }
    }
}