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
    public class ExpenseCategoryDAL
    {
        POSDBContext dbContext = new POSDBContext();
        public IEnumerable<SelectListItem> GetExpenseCategorySelectList()
        {
            var list = dbContext.ExpenseCategories.Where(x => x.ParentId == null).ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<ExpenseCategory> GetExpenseCategoryList()
        {
            var list = dbContext.ExpenseCategories.ToList();
            return list;
        }
        public string GetExpenseCategoryCode()
        {
            long code;

            if (dbContext.ExpenseCategories.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.ExpenseCategories.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:000}", (code + 1));
        }
        public bool IsExpenseCategorySaved(ExpenseCategoryVM itemVm)
        {
            ExpenseCategory item = new ExpenseCategory()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Description = itemVm.Description,
                Date = itemVm.Date,
                ParentId = itemVm.ParentId
            };

            dbContext.ExpenseCategories.Add(item);
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