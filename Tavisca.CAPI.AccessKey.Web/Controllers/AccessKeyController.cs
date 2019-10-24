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

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<AccessKeyResponse>> Create([FromBody] AccessKeyRequest key)
        {
            var result = await _accessKeyService.CreateKey(key);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        //[HttpGet]
        //[Route("getall/{clientName}")]
        //public async Task<ActionResult<AccessKeyDetails>> Get(String clientName)
        //{
        //    var result = await _accessKeyDatabaseService.getAccessKey(clientName);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}
    }
}