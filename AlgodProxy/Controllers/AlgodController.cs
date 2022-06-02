using Algorand.Algod.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
