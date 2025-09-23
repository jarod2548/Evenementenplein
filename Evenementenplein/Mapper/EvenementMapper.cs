using DAL;
using Evenementenplein.Models;
using Evenementenplein.ViewModels;
using EvenementenPleinMapper;

namespace Evenementenplein.Mapper
{
    public class EvenementMapper
    {
        public List<EvenementenViewModel> ConvertDTOsNaarModel(List<EvenementDTO> evenementDTOs)
        {
            List<EvenementenViewModel> viewModels = new List<EvenementenViewModel>();
            foreach(EvenementDTO dto in evenementDTOs)
            {
                EvenementenViewModel viewModel = new EvenementenViewModel()
                {
                    Naam = dto.Naam

                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public EvenementDTO ConvertModelToDTO(Evenement model, int locatieID)
        {
            EvenementDTO dto = new EvenementDTO() { 
                Naam = model.Naam,
                Beschrijving = model.Beschrijving,
                Capaciteit = model.Capaciteit,
                Type = Convert.ToInt32(model.Type),
                LocatieID = locatieID,
                BeginDatum = model.BeginDatum,
                EindDatum = model.EindDatum,
            };
            return dto;
        }
    }
}
