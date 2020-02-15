using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Communism.Api.Models;
using Communism.Domain.Contracts.Dtos;
using Communism.Domain.Contracts.ServiceInterfaces;

namespace Communism.Api.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IMapper _mapper;

        public ValuesController(IUserQueryService userQueryService, IMapper mapper)
        {
            _userQueryService = userQueryService;
            _mapper = mapper;
        }

        // GET api/values
        public IEnumerable<UserDto> Get()
        {
            var test2 = _mapper.Map<UserDto, UserModel>(new UserDto()
            {
                FirstName = "dadasd"
            });
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
