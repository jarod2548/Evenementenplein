
using DAL;
using EvenementenPleinMapper;

namespace BLL
{
    public class EvenementService
    {
        private readonly EvenementDAL dal;

        public EvenementService(EvenementDAL DAL)
        {
            dal = DAL;
        }

        public void VoegEvenementToe(EvenementDTO dto)
        {
            dal.VoegEvenementToe(dto);
        }

        public List<EvenementDTO> Ontvang10Evenementen()
        {
            List<EvenementDTO> evenementDTOs = dal.Ontvang10Evenementen();
            return evenementDTOs;
        }
    }
}
