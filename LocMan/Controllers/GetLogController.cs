using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocMan.BusinessLogic;
using LocMan.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocMan.Controllers
{
    public class GetLogController : Controller
    {
        private readonly LocDbContext _context;
        private readonly GetLog _log;

        public GetLogController(LocDbContext context, GetLog log)
        {
            _context = context;
            _log = log;
        }
        public IActionResult DistrictLogDetails(int? id)
        {
            return View();
        }
    }
}