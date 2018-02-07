using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.BLL.IServices.Books;

namespace Onion.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IBookService _ZepService;

        public ValuesController(IBookService ZepService)
        {
            _ZepService = ZepService;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            var user = User;
            return new string[] { "ok" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
