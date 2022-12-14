using Buckets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Buckets.Data;
using Buckets.Models;
using Buckets.Helpers;
//using Buckets.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Buckets.Enums;
using Buckets.Services;
using Buckets.Services.Interfaces;
using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Npgsql.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Buckets.Helpers
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString(string connectionString, string databaseUrl)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }
    
        //build the connection string from the environment. i.e. Heroku
        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}
