using System.Data.Common;
using NHibernate.Migration;

namespace NHibernate53AspNetCore31.Migrations
{
    [Migration("20200925143115_Initial", "1.0.0.0", Dialect = typeof(NHibernate.Dialect.MySQL57Dialect))]
    class Initial : Migration
    {
        public override void Up(NHibernate.Cfg.Configuration configuration, DbConnection connection)
        {
            connection.ExecuteNonQuery("create table aspnetroles (Id BIGINT NOT NULL AUTO_INCREMENT, Name VARCHAR(64) not null unique, NormalizedName VARCHAR(64) not null unique, ConcurrencyStamp VARCHAR(36), primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetroleclaims (Id INTEGER NOT NULL AUTO_INCREMENT, RoleId BIGINT not null, ClaimType TEXT not null, ClaimValue TEXT not null, primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetusers (Id BIGINT NOT NULL AUTO_INCREMENT, UserName VARCHAR(64) not null unique, NormalizedUserName VARCHAR(64) not null unique, Email TEXT not null, NormalizedEmail TEXT not null, EmailConfirmed TINYINT(1) not null, PhoneNumber VARCHAR(128), PhoneNumberConfirmed TINYINT(1) not null, LockoutEnabled TINYINT(1) not null, AccessFailedCount INTEGER not null, ConcurrencyStamp VARCHAR(36), PasswordHash TEXT, TwoFactorEnabled TINYINT(1) not null, SecurityStamp VARCHAR(64), primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetuserclaims (Id INTEGER NOT NULL AUTO_INCREMENT, UserId BIGINT not null, ClaimType TEXT not null, ClaimValue TEXT not null, primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetuserlogins (LoginProvider VARCHAR(32) not null, ProviderKey VARCHAR(32) not null, ProviderDisplayName VARCHAR(32) not null, UserId BIGINT not null, primary key (LoginProvider, ProviderKey))");
            connection.ExecuteNonQuery("create table aspnetuserroles (UserId BIGINT not null, RoleId BIGINT not null, primary key (UserId, RoleId))");
            connection.ExecuteNonQuery("create table aspnetusertokens (UserId BIGINT not null, LoginProvider VARCHAR(32) not null, Name VARCHAR(32) not null, Value TEXT not null, primary key (UserId, LoginProvider, Name))");
        }
    }
}

