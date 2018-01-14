using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POSManagementProject.Models.Context;
using POSManagementProject.Models.EntityModels;
using POSManagementProject.Models.ViewModels;
using System.Web.Mvc;

namespace POSManagementProject.DAL
{
    public class ItemDAL
    {
        POSDBContext dbContext = new POSDBContext();
        public IEnumerable<SelectListItem> GetItemSelectList()
        {
            var list = dbContext.ItemCategories.Select(x => x).Distinct().ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<Item> GetItemList()
        {
            var list = dbContext.Items.ToList();
            return list;
        }
        public bool IsItemSaved(ItemVM itemVm)
        {
            Item item = new Item()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Description = itemVm.Description,
                Image = itemVm.Image,
                Date = itemVm.Date,
                CategoryId = itemVm.CategoryId,
                CostPrice = itemVm.CostPrice,
                SalePrice = itemVm.SalePrice
            };

            dbContext.Items.Add(item);
            var isAdded = dbContext.SaveChanges();

            if (isAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}