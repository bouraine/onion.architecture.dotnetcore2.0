using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.BLL.IServices.Books;
using Onion.Web.API.Builders;

namespace Onion.Web.API.Controllers
{
    [Route("token")]
    public class ValuesController : Controller
    {
        private IBookService _BookService;

        public ValuesController(IBookService BookService)
        {
            _BookService = BookService;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            var user = User;
            var book = _BookService.GetById(1);
            var bvm = BookViewModelsBuilder.GetBookViewModel(book);
            
            return new string[] { "ok"};
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
