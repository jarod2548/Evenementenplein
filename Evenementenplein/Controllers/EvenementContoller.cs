using BLL;
using Evenementenplein.Models;
using EvenementenPleinMapper;
using Microsoft.AspNetCore.Mvc;

namespace Evenementenplein.Controllers
{
    public class EvenementContoller : Controller
    {
        private readonly EvenementService evenementService;

        public EvenementContoller(EvenementService EvenementService)
        {
            evenementService = EvenementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Evenementen()
        {
            return View();
        }
        public IActionResult MaakEvenementCompleet(Evenement model)
        {
            EvenementDTO dto = new EvenementDTO(model.Naam, model.Beschrijving);
            //evenementDAL.VoegEvenementToe("Test");
            return RedirectToAction("Evenementen");
        }
    }
}
