using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;


        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? initial, DateTime? finish)
        {
            if (!initial.HasValue)
            {
                initial = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!finish.HasValue)
            {
                finish = DateTime.Now;
            }

            ViewData["initial"] = initial.Value.ToString("yyyy-MM-dd");
            ViewData["finish"] = finish.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(initial, finish);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? initial, DateTime? finish)
        {
            if (!initial.HasValue)
            {
                initial = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!finish.HasValue)
            {
                finish = DateTime.Now;
            }

            ViewData["initial"] = initial.Value.ToString("yyyy-MM-dd");
            ViewData["finish"] = finish.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateGroupingAsync(initial, finish);

            return View(result);
        }
    }
}
