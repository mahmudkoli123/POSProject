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
    public class ItemVM
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [Required]
        [DisplayName("Cost Price")]
        public double CostPrice { get; set; }
        [DisplayName("Sale Price")]
        public double SalePrice { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Category")]
        public long CategoryId { get; set; }
        public virtual ItemCategory Category { get; set; }
        public List<Item> Items { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}