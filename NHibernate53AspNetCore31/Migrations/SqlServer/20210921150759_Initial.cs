using System.Data.Common;
using NHibernate.Migration;

namespace NHibernate53AspNetCore31.Migrations.SqlServer
{
    [Migration("20210921150759_Initial", "1.0.0.0", Dialect = typeof(NHibernate.Dialect.MsSql2008Dialect))]
    class Initial : Migration
    {
        public override void Up(NHibernate.Cfg.Configuration configuration, DbConnection connection)
        {
            connection.ExecuteNonQuery("create table aspnetroles (Id BIGINT IDENTITY NOT NULL, Name NVARCHAR(64) not null unique, NormalizedName NVARCHAR(64) not null unique, ConcurrencyStamp NVARCHAR(36) null, primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetroleclaims (Id INT IDENTITY NOT NULL, RoleId BIGINT not null, ClaimType NVARCHAR(1024) not null, ClaimValue NVARCHAR(1024) not null, primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetusers (Id BIGINT IDENTITY NOT NULL, UserName NVARCHAR(64) not null unique, NormalizedUserName NVARCHAR(64) not null unique, Email NVARCHAR(256) not null, NormalizedEmail NVARCHAR(256) not null, EmailConfirmed BIT not null, PhoneNumber NVARCHAR(128) null, PhoneNumberConfirmed BIT not null, LockoutEnabled BIT not null, AccessFailedCount INT not null, ConcurrencyStamp NVARCHAR(36) null, PasswordHash NVARCHAR(256) null, TwoFactorEnabled BIT not null, SecurityStamp NVARCHAR(64) null, primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetuserclaims (Id INT IDENTITY NOT NULL, UserId BIGINT not null, ClaimType NVARCHAR(1024) not null, ClaimValue NVARCHAR(1024) not null, primary key (Id))");
            connection.ExecuteNonQuery("create table aspnetuserlogins (LoginProvider NVARCHAR(32) not null, ProviderKey NVARCHAR(32) not null, ProviderDisplayName NVARCHAR(32) not null, UserId BIGINT not null, primary key (LoginProvider, ProviderKey))");
            connection.ExecuteNonQuery("create table aspnetuserroles (UserId BIGINT not null, RoleId BIGINT not null, primary key (UserId, RoleId))");
            connection.ExecuteNonQuery("create table aspnetusertokens (UserId BIGINT not null, LoginProvider NVARCHAR(32) not null, Name NVARCHAR(32) not null, Value NVARCHAR(256) not null, primary key (UserId, LoginProvider, Name))");
            connection.ExecuteNonQuery("create table Document (Id BIGINT IDENTITY NOT NULL, Number INT null, Year INT null, Date DATE null, Subject NVARCHAR(2048) null, primary key (Id))");
        }
    }
}
