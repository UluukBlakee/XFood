﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFood.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ContactInfo { get; set; }
        public int PizzeriaId { get; set; }
        public Pizzeria? Pizzeria { get; set; }
    }
}
