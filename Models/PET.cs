﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace animal.adoption.api.Models
{
    public class PET
    {
     [Column("id"), Key]
     public int Id { get; set; }

     [Column("name")]
     public string? Name { get; set; }

     [Column("color")]
     public string? Color { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("shelter")]
    public string? Shelter { get; set; }

    [Column("size")]
    public int? Size { get; set; }

    [Column("hair_length")]
    public string? HairLength { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }
    }
}
