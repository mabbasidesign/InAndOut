using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: ExpenseController
        public IActionResult Index()
        {
            var objList = _db.Expenses;

            foreach(var obj in objList)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }

            return View(objList);
        }      

        // GET: ExpenseController/Create
        public IActionResult Create()
        {
            var expenseVM = new ExpenseVM
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(expenseVM);
        }

        // POST: ExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM expenseVM)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseVM);
        }
     

        // GET: ExpenseController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpenseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
