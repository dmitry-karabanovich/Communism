using System.Collections.Generic;
using System.Web.Http;
using Communism.Domain.Contracts.Dtos;
using Communism.Domain.Contracts.ServiceInterfaces;

namespace Communism.Api.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IUserQueryService _userQueryService;

        public ValuesController(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        // GET api/values
        public IEnumerable<UserDto> Get()
        {
            return new[] { _userQueryService.GetUserByUserName("dkarabanovich") };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
