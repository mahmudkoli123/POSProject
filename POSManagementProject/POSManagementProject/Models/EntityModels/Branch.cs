using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POSManagementProject.Models.EntityModels
{
    public class Branch
    {
        public long Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}