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

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<List<GetAllKeysResponse>>> Get()
        {
            var result = await _accessKeyService.GetAllKeys();
            return result == null ? (ActionResult<List<GetAllKeysResponse>>)NotFound() : (ActionResult<List<GetAllKeysResponse>>)Ok(result);
        }

        [HttpPost]
        [Route("generatenew")]
        public async Task<ActionResult<AccessKeyResponse>> Create([FromBody] AccessKeyRequest key)
        {
            var result = await _accessKeyService.CreateKey(key);
            return result == null ? (ActionResult<AccessKeyResponse>)BadRequest() : (ActionResult<AccessKeyResponse>)Ok(result);
        }
        [HttpPut]
        [Route("activate/{clientId}")]
        public async Task<ActionResult<ActivateKeyResponse>> Activate(string clientId, [FromBody] ActivateKeyRequest accessKey)
        {
            var result = await _accessKeyService.ActivateKey(accessKey);
            return result == null ? (ActionResult<ActivateKeyResponse>)BadRequest() : (ActionResult<ActivateKeyResponse>)Ok(result);
        }
        [HttpPut]
        [Route("deactivate/{clientId}")]
        public async Task<ActionResult<DeactivateKeyResponse>> Deactivate(string clientId,[FromBody] DeactivateKeyRequest keyRequest)
        {
            var result = await _accessKeyService.DeactivateKey(keyRequest);
            return result == null ? (ActionResult<DeactivateKeyResponse>)BadRequest() : (ActionResult<DeactivateKeyResponse>)Ok(result);
        }
    }
}