﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BBK_A2_SWE5201_2201525.Data.BBKDB;

public partial class Bike
{
    public int BikeId { get; set; }

    public string BikeModel { get; set; }

    public int CyclistId { get; set; }

    public virtual Cyclist Cyclist { get; set; }

    public virtual ICollection<Repair> Repair { get; set; } = new List<Repair>();
}