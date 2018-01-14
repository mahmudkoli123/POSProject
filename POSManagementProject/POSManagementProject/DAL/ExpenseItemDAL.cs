using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.Models.Context;
using POSManagementProject.Models.EntityModels;
using POSManagementProject.Models.ViewModels;

namespace POSManagementProject.DAL
{
    public class ExpenseItemDAL
    {
        POSDBContext dbContext = new POSDBContext();
        public IEnumerable<SelectListItem> GetExpenseItemSelectList()
        {
            var list = dbContext.ExpenseCategories.Select(x => x).Distinct().ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<ExpenseItem> GetExpenseItemList()
        {
            var list = dbContext.ExpenseItems.ToList();
            return list;
        }
        public bool IsExpenseItemSaved(ExpenseItemVM itemVm)
        {
            ExpenseItem item = new ExpenseItem()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Description = itemVm.Description,
                Date = itemVm.Date,
                CategoryId = itemVm.CategoryId
            };

            dbContext.ExpenseItems.Add(item);
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