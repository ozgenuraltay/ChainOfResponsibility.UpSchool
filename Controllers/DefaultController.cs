using ChainOfResponsibility.UpSchool.ChainOfResponsibility;
using ChainOfResponsibility.UpSchool.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility.UpSchool.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(WithdrawVM withdraw)
        {
            Employee treasurer = new Treasurer();
            Employee managerasistant = new ManagerAsistant();
            Employee manager = new Manager();
            Employee regionManager = new RegionManager();

            treasurer.SetNextApprover(managerasistant);
            managerasistant.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            treasurer.ProcessRequest(withdraw);
            return View();
        }
    }
}
