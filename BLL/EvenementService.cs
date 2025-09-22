
using DAL;
using EvenementenPleinMapper;

namespace BLL
{
    public class EvenementService
    {
        private readonly EvenementDAL DAL;

        public EvenementService(EvenementDAL dAL)
        {
            DAL = dAL;
        }

        public void VoegEvenementToe(EvenementDTO dto)
        {
            
        }
    }
}
