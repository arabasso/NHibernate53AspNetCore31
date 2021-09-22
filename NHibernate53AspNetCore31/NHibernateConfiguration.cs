using System.Security.Permissions;
using NHibernate.Mapping.ByCode;
using NHibernate53AspNetCore31.Models.Mappings;

namespace NHibernate53AspNetCore31
{
    public class NHibernateConfiguration :
        NHibernate.Cfg.Configuration
    {
        public NHibernateConfiguration(
            string connectionString)
        {
            this.Use(connectionString)
                .AddIdentityMapping<Models.IdentityUser<long>, long>();

            var mapper = new ModelMapper();

            mapper.AddMapping<DocumentMapping>();

            AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
        }
    }
}
