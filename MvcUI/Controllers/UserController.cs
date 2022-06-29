using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserDTO createUserDTO)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(createUserDTO);
                ViewBag.message = "User created";
                return View();
            }

            return View(createUserDTO);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);
            return View(new UpdateUserDTO
            {
                CarNumberPlate = user.CarNumberPlate,
                Email=user.Email,
                IdentificationNumber=user.IdentificationNumber,
                Name=user.Name,
                Phone=user.Phone
            });
        }

        [HttpPost]
        public IActionResult Edit(int id,UpdateUserDTO updateUserDTO)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(id, updateUserDTO);
                return RedirectToAction("GetUsers", "User");
            }
            return View(updateUserDTO);
        }

        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("GetUsers", "User");
        }
    }
}
