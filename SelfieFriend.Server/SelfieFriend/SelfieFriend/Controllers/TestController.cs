using SelfieFriend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SelfieFriend.Controllers
{
    public class TestController : ApiController
    {
        private readonly IFileService _fileService;

        public TestController(IFileService fileService)
        {
            _fileService = fileService;
        }


        [HttpGet]
        [Route("Test")]
        public void Test()
        {
            _fileService.test();
        }

    }
}
