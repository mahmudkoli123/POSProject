using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POSManagementProject.Models.EntityModels
{
    public class Employee
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
        public string EmergencyContact { get; set; }
        public string NID { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }

        [Required]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public long? ReferenceId { get; set; }
        public virtual Employee Reference { get; set; }

    }
}