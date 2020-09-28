using System.Security.Permissions;

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
        }
    }
}
