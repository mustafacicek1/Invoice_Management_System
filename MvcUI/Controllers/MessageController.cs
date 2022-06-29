using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcUI.Controllers
{
    public class MessageController : Controller
    {

        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult GetMessages()
        {
            var messages = _messageService.MessageList();
            return View(messages);
        }

        [Authorize(Roles ="User")]
        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [Authorize(Roles ="User")]
        [HttpPost]
        public IActionResult Send(CreateMessageDTO createMessageDTO)
        {
            string? id = HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(id);
            createMessageDTO.UserId = userId;

            _messageService.SendMessage(createMessageDTO);
            ViewBag.message = "Your message sent";
            return View(createMessageDTO);
        }
    }
}
