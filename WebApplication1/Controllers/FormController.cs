using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

public class FormController : Controller
{
    private readonly ILogger<FormController> _logger;
    private readonly FormDbContext _context;
    public FormController(ILogger<FormController> logger, FormDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Talk()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Post()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Posts(FormModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Add(model);
            _context.SaveChanges();
            string emailSubject = "Thank You for contacting CodeAxis";
            string? username = model.Name;
            string emailMessage = "Dear " + username + "\n" +
                                "We received your message. Thank you for contacting us.\n" +
                                "Our team will contact you very soon.\n" +
                                "Best Regards\n\n" +
                                "Your Message:\n" + model.Message;
            EmailSender emailSender = new EmailSender();
            await emailSender.SendEmail(model.Email!, username!, emailSubject, emailMessage);
            return RedirectToAction("Talk"); 
        }
        ViewBag.Message = "Message successfully sent.";
        return RedirectToAction("Talk", model);
    }
    // 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
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}