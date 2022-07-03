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

        [Authorize(Roles ="User")]
        [HttpGet]
        public IActionResult UserInvoices()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AdminInvoices()
        {
            return View();
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
