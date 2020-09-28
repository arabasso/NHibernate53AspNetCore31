using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using NHibernate.Cfg;
using NHibernate.Linq;

namespace NHibernate53AspNetCore31
{
    public class DataBaseProviderNotFoundException
        : Exception
    {
        public DataBaseProviderNotFoundException(
            string message)
            : base(message)
        {
        }
    }

    public static class NHibernateExtensions
    {
        public static Configuration Use(
            this Configuration configuration,
            string connectionString)
        {
            var match = Regex.Match(connectionString, @"provider=(?<provider>[^;]+);?", RegexOptions.IgnoreCase);

            if (!match.Success) throw new DataBaseProviderNotFoundException("Provider not found");

            connectionString = connectionString.Replace(match.Value, string.Empty);

            switch (match.Groups["provider"].Value.ToLower())
            {
                case "sqlserver":
                    return configuration.Use<NHibernate.Driver.SqlClientDriver, NHibernate.Dialect.MsSql2008Dialect>(connectionString);

                case "mysql":
                    return configuration.Use<NHibernate.Driver.MySqlDataDriver, NHibernate.Dialect.MySQL57Dialect>(connectionString);

                case "npgsql":
                    return configuration.Use<NHibernate.Driver.NpgsqlDriver, NHibernate.Dialect.PostgreSQL83Dialect>(connectionString);

                case "firebird":
                    return configuration.Use<NHibernate.Driver.FirebirdClientDriver, NHibernate.Dialect.FirebirdDialect>(connectionString);

                case "oracle":
                    return configuration.Use<NHibernate.Driver.OracleManagedDataClientDriver, NHibernate.Dialect.Oracle12cDialect>(connectionString);

                default:
                    throw new DataBaseProviderNotFoundException("Provider not found");
            }
        }

        public static Configuration Use<TDriver, TDialect>(
            this Configuration configuration,
            string connectionString)
            where TDriver : NHibernate.Driver.DriverBase
            where TDialect : NHibernate.Dialect.Dialect
        {
            configuration.DataBaseIntegration(db =>
            {
                db.Driver<TDriver>();
                db.Dialect<TDialect>();
                db.ConnectionString = connectionString;
                db.AutoCommentSql = true;
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            });

            return configuration;
        }

        public static Configuration WithSchemaCreate(
            this Configuration configuration)
        {
            configuration.DataBaseIntegration(db => db.SchemaAction = SchemaAutoAction.Create);

            return configuration;
        }

        public static INhFetchRequest<TEntity, TRelated> Include<TEntity, TRelated>(
            this IQueryable<TEntity> queryable, Expression<Func<TEntity, TRelated>> expression)
        {
            return queryable.Fetch(expression);
        }
    }
}