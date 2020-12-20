using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase {

        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public string Get() {

            return string.Empty;
        }
    }
}
