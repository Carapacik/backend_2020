using Microsoft.AspNetCore.Mvc;
using System;
using Translator.Models;

namespace Translator.Controllers
{
    public class TranslatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Translate(string id)
        {
            Models.Translator dict = new Models.Translator("dictionary.txt");
            string translation = dict.Transalte(id);
            var translaedWord = new TranslateView() { UntranslatedWord = id, TranslatedWord = translation };

            if (String.IsNullOrEmpty(translation))
            {
                return new NotFoundObjectResult(new { error = "Word not found", id }) { StatusCode = 404 };
            }

            //return Content(translation);
            return View(translaedWord);
        }

        [HttpPost]
        public IActionResult Search(TranslateView model)
        {
            Models.Translator dict = new Models.Translator("dictionary.txt");
            string translation = dict.Transalte(model.UntranslatedWord.ToLower());
            var translaedWord = new TranslateView() { UntranslatedWord = model.UntranslatedWord, TranslatedWord = translation };

            if (String.IsNullOrEmpty(translation))
            {
                return new NotFoundObjectResult(new { error = "Word not found", model.UntranslatedWord }) { StatusCode = 404 };
            }

            //return Content(translation);
            return View("Translate", translaedWord);
        }
    }
}
