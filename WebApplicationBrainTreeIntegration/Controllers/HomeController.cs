using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Braintree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationBrainTreeIntegration.Data;
using WebApplicationBrainTreeIntegration.Models;
using WebApplicationBrainTreeIntegration.Models.Repository;

namespace WebApplicationBrainTreeIntegration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db,IBookRepository bookRepository)
        {
            _db = db;
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
        
            return View(_bookRepository.GetBooks());
        }


        public IActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {

                _bookRepository.AddBook(model);
                var gateway = new BraintreeGateway
                {
                    Environment = Braintree.Environment.SANDBOX,
                    MerchantId = "ky2tx7gt7vzq5jqg",
                    PublicKey = "jpwzrh38bnv5zk36",
                    PrivateKey = "8788471d79e6aaf5eff47a6f2e003024"
                };


                TransactionRequest request = new TransactionRequest
                {
                    Amount = Convert.ToDecimal(model.Price),
                    PaymentMethodNonce = "fake-valid-nonce",
                    Options = new TransactionOptionsRequest
                    {
                        SubmitForSettlement = true
                    }
                };
                Result<Transaction> result = gateway.Transaction.Sale(request);
                if (result.IsSuccess())
                {
                    Transaction transaction = result.Target;
                    return RedirectToAction("Success", new { id = transaction.Id });
                }
                else
                {
                    return Redirect(nameof(Error));
                }


            }
            return View(model);
        }
        public IActionResult Success(string id)
        {
            ViewBag.ID = id;
            return View();
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
