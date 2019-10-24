using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Tavisca.CAPI.AccessKey.Model.Models.DataContracts;

namespace Tavisca.CAPI.AccessKey.Web.Controllers
{
    [Route("accesskey")]
    [ApiController]
    public class AccessKeyController : ControllerBase
    {
        private readonly IAccessKeyService _accessKeyService;
        public AccessKeyController(IAccessKeyService accessKeyService)
        {
            _accessKeyService = accessKeyService;
        }
        // GET accesskey/getall
        [HttpGet]
        [Route("getallkeys")]
        public async Task<ActionResult<List<GetAllKeysResponse>>> Get()
        {
            var result = await _accessKeyService.GetAllKeys();
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut]
        [Route("activate/{clientId}")]
        public async Task<ActionResult<ActivateKeyResponse>> Activate(string clientId, [FromBody] ActivateKeyRequest accessKey)
        {
            var result = await _accessKeyService.ActivateKey(accessKey);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        [Route("deactivate/{clientId}")]
        public async Task<ActionResult<DeactivateKeyResponse>> Put(string clientId,[FromBody] DeactivateKeyRequest keyRequest)
        {
            var result = await _accessKeyService.DeactivateKey(keyRequest);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}