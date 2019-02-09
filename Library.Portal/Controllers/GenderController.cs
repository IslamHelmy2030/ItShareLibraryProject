using System.Threading.Tasks;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto;
using Library.Domain.Dto.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Library.Portal.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderBusiness _genderBusiness;

        public GenderController(IGenderBusiness genderBusiness)
        {
            _genderBusiness = genderBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var genders = await _genderBusiness.GetAllGenders();
            return View(genders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var gender = await _genderBusiness.GetGender(id);
            return View(gender);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenderParameter gender)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _genderBusiness.AddGender(gender);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var gender = await _genderBusiness.GetGender(id);
            return View(gender);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenderDto gender)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _genderBusiness.UpdateGender(gender);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var gender = await _genderBusiness.GetGender(id);
            return View(gender);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GenderDto gender)
        {
            var isDeleted = await _genderBusiness.DeleteGender(gender.Id);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
