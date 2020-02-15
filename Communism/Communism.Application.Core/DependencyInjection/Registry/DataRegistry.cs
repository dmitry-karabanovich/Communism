using Communism.Data.EntityFramework.Repositories;

namespace Communism.Application.Core.DependencyInjection.Registry
{
    public class DataRegistry : StructureMap.Registry
    {
        public DataRegistry()
        {
            Scan(y =>
            {
                y.AssemblyContainingType<UserRepository>();
                y.WithDefaultConventions();
                y.AssembliesFromApplicationBaseDirectory(z => z.FullName.EndsWith("Repository"));
            });
        }
    }
}
