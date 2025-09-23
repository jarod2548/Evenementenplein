using Contracts;
using DAL;
using Evenementenplein.Models;
using Evenementenplein.Models.Enums;
using Evenementenplein.ViewModels;
using EvenementenPleinMapper;

namespace Evenementenplein.Mapper
{
    public class EvenementMapper
    {
        public EvenementenViewModel ConvertDTOsNaarModel(EvenementDTO evenementDTO, LocatieDTO locatieDTO)
        {
            EvenementenViewModel viewModel = new EvenementenViewModel()
            {
                Naam = evenementDTO.Naam,
                Type = ((EvenementType)evenementDTO.EvenementType).ToString(),
                LocatieNaam = locatieDTO.Naam,
                LocatieAdres = locatieDTO.Adres,
                BeginDatum = evenementDTO.BeginDatum.ToShortDateString(),
                EindDatum = evenementDTO.EindDatum.ToShortDateString(),
            };
            
            return viewModel;
        }

        public EvenementDTO ConvertModelToDTO(Evenement model, int locatieID)
        {
            EvenementDTO dto = new EvenementDTO() { 
                Naam = model.Naam,
                Beschrijving = model.Beschrijving,
                Capaciteit = model.Capaciteit,
                EvenementType = Convert.ToInt32(model.Type),
                LocatieID = locatieID,
                BeginDatum = model.BeginDatum,
                EindDatum = model.EindDatum,
            };
            return dto;
        }
    }
}
