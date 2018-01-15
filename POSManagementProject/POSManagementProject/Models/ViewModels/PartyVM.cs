using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using POSManagementProject.Models.EntityModels;

namespace POSManagementProject.Models.ViewModels
{
    public class PartyVM
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Customer")]
        public bool IsCustomer { get; set; }
        [DisplayName("Supplier")]
        public bool IsSupplier { get; set; }

        public List<Party> Parties { get; set; }
        

    }
}