using Algorand.Algod.Model.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlgodProxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlgodController : ControllerBase
    {


        private readonly ILogger<AlgodController> _logger;

        public AlgodController(ILogger<AlgodController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public SignedTransaction Get()
        {
            return null;
        }
    }
}
