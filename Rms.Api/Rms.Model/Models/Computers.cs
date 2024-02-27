﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rms.Models;

public partial class Computers
{
    [Key]
    public int SLNo { get; set; }

    [Required]
    [StringLength(12)]
    [Unicode(false)]
    public string PhysicalAddress { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string WorkStationName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string BranchCode { get; set; }

    public bool? Active { get; set; }
}