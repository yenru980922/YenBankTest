
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.EFModels;

public partial class Account
{
    [Key]
    [StringLength(36)]
    [Unicode(false)]
    public string AccountGuid { get; set; }

    [StringLength(36)]
    [Unicode(false)]
    public string OwnerGuid { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("AcctSerialID")]
    public int? AcctSerialId { get; set; }

    public int? AccountKind { get; set; }

    [StringLength(50)]
    public string AccountName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string AccountStatus { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CacheTime { get; set; }

    [ForeignKey("OwnerGuid")]
    [InverseProperty("Accounts")]
    public virtual NetBankUser Owner { get; set; }
}