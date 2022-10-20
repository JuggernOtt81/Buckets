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

namespace Buckets.Models
{
    public class BankAccount
    {
        public string? Id { get; set; }
        public string? AccountName { get; set; }
        public string? BankName { get; set; }
        public string? RoutingNumber { get; set; }
        public string? AccountNumber { get; set; }
        public string? Description { get; set; }
        public string? ReportedBalance { get; set; }
        public string? AdjustedBalance { get; set; }
        public string AccountHeader { get { return $"{AccountName} | {BankName} | {AccountNumber}"; } }
    }
}
