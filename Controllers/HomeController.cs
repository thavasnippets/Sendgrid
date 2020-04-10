using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SendGrid_StorageAccount.Helper;
using SendGrid_StorageAccount.Models;

namespace SendGrid_StorageAccount.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;
        
        public HomeController(IEmailSender emailSender)
        {

            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendEmail()
        {
            EmailModel model = new EmailModel();
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                var emails = new List<string>();
                emails.Add(model.Email);
                await _emailSender.SendEmailAsync(emails, model.Subject, model.Message);
            }
            return View(model);
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
