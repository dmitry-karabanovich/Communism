using System;

namespace Communism.Domain.Contracts.Dtos
{
    public class UserDto
    {
        public Guid Uid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
    }
}
