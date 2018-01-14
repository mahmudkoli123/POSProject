using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.Models.EntityModels;

namespace POSManagementProject.Models.ViewModels
{
    public class EmployeeVM
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Email { get; set; }
        [DisplayName("Emergency Contact")]
        public string EmergencyContact { get; set; }
        public string NID { get; set; }
        [DisplayName("Father's Name")]
        public string FathersName { get; set; }
        [DisplayName("Mother's Name")]
        public string MothersName { get; set; }
        [DisplayName("Present Address")]
        public string PresentAddress { get; set; }
        [DisplayName("Permanent Address")]
        public string PermanentAddress { get; set; }
        [DisplayName("Joining Date")]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }

        [Required]
        [DisplayName("Branch")]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        [DisplayName("Reference")]
        public long? ReferenceId { get; set; }
        public virtual Employee Reference { get; set; }

        public List<Employee> Employees { get; set; }

        public IEnumerable<SelectListItem> SelectListReference { get; set; }
        public IEnumerable<SelectListItem> SelectListBranch { get; set; }
    }
}