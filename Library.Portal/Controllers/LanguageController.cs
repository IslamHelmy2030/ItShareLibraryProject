using System.Threading.Tasks;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Library.Portal.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageBusiness _languageBusiness;

        public LanguageController(ILanguageBusiness languageBusiness)
        {
            _languageBusiness = languageBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _languageBusiness.GetAllLanguages();
            return View("Index", result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _languageBusiness.GetLanguage(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LanguageDto language)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _languageBusiness.UpdateLanguage(language);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(language);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageParameter language)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _languageBusiness.AddLanguage(language);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(language);
        }

        public async Task<IActionResult> Details(int id)
        {

            var result = await _languageBusiness.GetLanguage(id);
            return View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _languageBusiness.DeleteLanguage(id);
            return RedirectToAction("Index");
        }
    }
}