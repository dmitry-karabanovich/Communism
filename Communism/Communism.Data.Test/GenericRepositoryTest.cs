using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;

namespace Communism.Data.Test
{
    public abstract class GenericRepositoryTest<T> where T : class
    {
        

        public void Add_TDto_AddAppropriateEntity<TDto>(TDto dtoToAdd)
        {

        }

        public void GetAllUser_ReceiveAppropriateUsers_Test()
        {

        }

        
    }
}
