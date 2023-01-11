using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VDITest_MuhammadRidwan._2._Services.IService;
using VDITest_MuhammadRidwan.Models;

namespace VDITest_MuhammadRidwan.Controllers
{
    public class HomeController : Controller
    {
        IMemberService _memberService;
        
        public HomeController(IMemberService memberService, IWebHostEnvironment webHostEnvironment)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _memberService.GetAll();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _memberService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberModel model)
        {
            await _memberService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _memberService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MemberModel model)
        {
            await _memberService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _memberService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}