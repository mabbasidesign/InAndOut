using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: ExpenseTypeController
        public ActionResult Index()
        {
            var objList = _db.ExpenseTypes;
            return View(objList);
        }

        // GET: ExpenseTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpenseTypeController/Create
       
    }
}
