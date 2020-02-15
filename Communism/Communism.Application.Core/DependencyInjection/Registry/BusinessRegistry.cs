using Communism.Domain.Services;

namespace Communism.Application.Core.DependencyInjection.Registry
{
    public class BusinessRegistry : StructureMap.Registry
    {
        public BusinessRegistry()
        {
            Scan(y =>
            {
                y.AssemblyContainingType<UserQueryService>();
                y.WithDefaultConventions();
                y.AssembliesFromApplicationBaseDirectory(z => z.FullName.EndsWith("Services"));
            });

        }
    }
}
