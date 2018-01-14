using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POSManagementProject.Models.EntityModels
{
    public class Organization
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
    }
}