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
    public class Bill
    {
        public string? Id { get; set; }
        public string? BillName { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? Classification { get; set; }
        public string? Priority { get; set; }
        public string? AccountNumber { get; set; }
        public double PastDueAmount { get; set; }
        public double PrePaidCreditAmount { get; set; }
        public double CurrentDueAmount { get; set; }
        public string BillHeader { get { return $"{BillName} | {CompanyName} | {AccountNumber}"; } }
    }
}
