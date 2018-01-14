using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POSManagementProject.Models.EntityModels
{
    public class ExpenseItem
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public long CategoryId { get; set; }
        public virtual ExpenseCategory Category { get; set; }
    }
}