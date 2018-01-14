using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.Models.EntityModels;

namespace POSManagementProject.Models.ViewModels
{
    public class BranchVM
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

        public List<Branch> Branches { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}