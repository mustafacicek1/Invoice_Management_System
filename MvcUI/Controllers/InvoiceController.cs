using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcUI.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult GetDebts()
        {
            var debts = _invoiceService.GetDebtList();
            return View(debts);
        }

        [Authorize(Roles ="User,Admin")]
        [HttpGet]
        public IActionResult GetMyInvoices()
        {
            string? id = HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(id);
            var invoices = _invoiceService.GetInvocesByUserId(userId);
            return View(invoices);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateInvoiceDTO createInvoiceDTO)
        {
            if (ModelState.IsValid)
            {
                _invoiceService.AddInvoice(createInvoiceDTO);
                ViewBag.message = "Invoice created";
                return View();
            }

            return View(createInvoiceDTO);
        }
    }
}
