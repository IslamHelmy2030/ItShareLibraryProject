using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Portal.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorBusiness _authorBusiness;
        private readonly IGenderBusiness _genderBusiness;

        public AuthorController(IAuthorBusiness authorBusiness, IGenderBusiness genderBusiness)
        {
            _authorBusiness = authorBusiness;
            _genderBusiness = genderBusiness;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _authorBusiness.GetAllAuthors();
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _authorBusiness.GetAuthor(id);
            return View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _authorBusiness.DeleteAuthor(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            await SetDropDownList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAuthorParameter author)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _authorBusiness.AddAuthor(author);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(author);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorBusiness.GetAuthor(id);
            await SetDropDownList(author.GenderName);
            return View(author);
        }

        private async Task SetDropDownList(string authorGenderName = null)
        {
            var genders = await _genderBusiness.GetAllGenders();
            IList<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var genderDto in genders)
            {
                SelectListItem mySelectListItem = new SelectListItem
                {
                    Text = genderDto.GenderType,
                    Value = genderDto.Id.ToString(),
                    Selected = authorGenderName == genderDto.GenderType
                };
                selectListItems.Add(mySelectListItem);
            }

            ViewData["GenderList"] = selectListItems;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAuthorParameter author)
        {
            await _authorBusiness.UpdateAuthor(author);
            return RedirectToAction("Index");
        }
    }
}