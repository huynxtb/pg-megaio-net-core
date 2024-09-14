using System.Diagnostics;
using CodeMegaUploadFileMegaZ.MegaService;
using Microsoft.AspNetCore.Mvc;
using CodeMegaUploadFileMegaZ.Models;

namespace CodeMegaUploadFileMegaZ.Controllers;

public class HomeController : Controller
{
    private readonly IMegaService _megaService;

    public HomeController(IMegaService megaService)
    {
        _megaService = megaService;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _megaService.GetListAsync("CodeMega");
        
        return View(data);
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var folderName = "CodeMega";

        await _megaService.UploadAsync(file, folderName);
        
        return Redirect("/");
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteFile(string downloadUrl)
    {
        await _megaService.DeleteAsync(downloadUrl);
        
        return Redirect("/");
    }
    
    [HttpGet]
    public async Task<IActionResult> DownloadFile(string downloadUrl, string fileName)
    {
        var data = await _megaService.DownloadAsync(downloadUrl);
        
        return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
}