using IronPdf;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VDITest_MuhammadRidwan._2._Services.IService;
using VDITest_MuhammadRidwan.Models;
using Path = System.IO.Path;

namespace VDITest_MuhammadRidwan.Controllers
{
    public class HomeController : Controller
    {
        IMemberService _memberService;
        IServiceProvider _serviceProvider;
        IWebHostEnvironment _webHostEnvironment;


        public HomeController(IMemberService memberService, IWebHostEnvironment webHostEnvironment, IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment1)
        {
            _memberService = memberService;
            _serviceProvider = serviceProvider;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create([FromForm]MemberModel model)
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _memberService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitDelete(int id)
        {
            await _memberService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExportToPdf(MemberModel model)
        {
            Installation.TempFolderPath = @"{_host.ContentRootPath}/irontemp/";
            Installation.LinuxAndDockerDependenciesAutoConfig = true;
            var charsToRemove = new string[] { @"\" };
            foreach (var c in charsToRemove)
            {
                model.AvatarUrl = model.AvatarUrl.Replace(c, string.Empty);

            }
            model.AvatarUrl = model.AvatarUrl.Substring(1);
            string serverUrl = Path.Combine(_webHostEnvironment.WebRootPath, model.AvatarUrl);
            model.AvatarUrl = serverUrl;
            var html = this.RenderViewAsync("Details", model, true);
            var ironPdfRender = new IronPdf.ChromePdfRenderer();
            using var pdfDoc = ironPdfRender.RenderHtmlAsPdf(html.Result);
            return File(pdfDoc.Stream.ToArray(), "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}