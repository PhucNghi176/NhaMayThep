﻿using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("DonViCongTac")]
    public class DonViCongTacEntity
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
