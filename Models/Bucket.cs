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
//using Buckets.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Npgsql.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
namespace Buckets.Models
{
    public class Bucket
    {
        public string? Id { get; set; }
        public string? BucketName { get; set; }
        public string? Priority { get; set; }
        public double Income { get; set; }
        public double BucketCapacity { get; set; }
        public double Expense { get; set; }

        public string AccountHeader { get { return $"{BucketName} | {BucketCapacity} | {Priority}"; } }
        public double Spillover { get { return ((BucketCapacity - Expense) + Income); } }
    }
}
