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

namespace Buckets.Models
{
    public class Expense
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        //public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
