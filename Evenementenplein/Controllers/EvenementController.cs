using BLL;
using Contracts;
using Evenementenplein.Mapper;
using Evenementenplein.Models;
using Evenementenplein.Models.Enums;
using Evenementenplein.ViewModels;
using EvenementenPleinMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Evenementenplein.Controllers
{
    public class EvenementController : Controller
    {
        private readonly EvenementService evenementService;
        private readonly LocatieService locatieService;
        private readonly EvenementMapper evenementMapper;

        public EvenementController(EvenementService EvenementService, LocatieService LocatieService)
        {
            evenementService = EvenementService;
            locatieService = LocatieService;
            evenementMapper = new EvenementMapper();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Evenementen()
        {
            List<EvenementDTO> evenementenDTOs = evenementService.Ontvang10Evenementen();

            List<EvenementenViewModel> viewModels = evenementMapper.ConvertDTOsNaarModel(evenementenDTOs);

            return View(viewModels);
        }

        public IActionResult EvenementForm()
        {
            return View();
        }
        public IActionResult MaakEvenementCompleet(Evenement model)
        {
            if (!ModelState.IsValid)
            {
                return View("EvenementForm", model);
            }

            int locatieID = locatieService.VoegLocatieToeMetID(model.Locatie.Naam, model.Locatie.Adres);

            EvenementDTO dto = evenementMapper.ConvertModelToDTO(model, locatieID);

            evenementService.VoegEvenementToe(dto);

            return RedirectToAction("Evenementen");
        }
    }
}
