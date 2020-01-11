using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeventhServices.Resource.Asset.SqlLoader;
using SeventhServices.Resource.Asset.SqlLoader.Classes;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CutController : ControllerBase
    {


        private readonly ILogger<CutController> _logger;
        private readonly LocalDbLoader _loader;

        public CutController(ILogger<CutController> logger, LocalDbLoader loader)
        {
            _logger = logger;
            _loader = loader;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAll()
        {
            var card = await Task.Run(() => _loader.TryLoad<Card>());
            return  Ok(card);

        }
    }
}

