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
    public class ItemCategoryVM
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Parent Category")]
        public long? ParentId { get; set; }
        public virtual ItemCategory Parent { get; set; }
        public List<ItemCategory> ItemCategories { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}