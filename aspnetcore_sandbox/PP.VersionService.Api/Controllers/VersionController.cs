using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PP.VersionServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly ILogger<VersionController> _logger;
        private readonly VersionService _versionService;

        public VersionController(ILogger<VersionController> logger, VersionService versionService)
        {
            _versionService = versionService;
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return _versionService.GetFileVersion();
        }
    }
}
