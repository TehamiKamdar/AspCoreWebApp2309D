﻿using System.ComponentModel.DataAnnotations;

namespace AspCoreWebApp2309D.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
    }
}
