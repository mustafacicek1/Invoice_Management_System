using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public IActionResult GetApartments()
        {
            var apartments = _apartmentService.GetApartments();
            return View(apartments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateApartmentDTO createApartmentDTO)
        {
            if (ModelState.IsValid)
            {
                _apartmentService.Add(createApartmentDTO);
                ViewBag.message = "Apartment created";
                return View();
            }

            return View(createApartmentDTO);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var apartment = _apartmentService.GetApartment(id);
            return View(new UpdateApartmentDTO
            { 
                ApartmentNo =apartment.ApartmentNo,
                Blok=apartment.Blok,
                FloorNumber =apartment.FloorNumber,
                IsEmpty=apartment.IsEmpty,
                Type =apartment.Type,
                UserId = apartment.UserId,
            });
        }

        [HttpPost]
        public IActionResult Edit(int id,UpdateApartmentDTO updateApartmentDTO)
        {
            if (ModelState.IsValid)
            {
                _apartmentService.Update(id, updateApartmentDTO);
                return RedirectToAction("GetApartments", "Apartment");
            }
            return View(updateApartmentDTO);
        }

        public IActionResult Delete(int id)
        {
            _apartmentService.Delete(id);
            return RedirectToAction("GetApartments", "Apartment");
        }
    }
}
