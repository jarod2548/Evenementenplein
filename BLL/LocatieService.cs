using Contracts;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LocatieService
    {
        private readonly LocatieDAL dal;

        public LocatieService(LocatieDAL DAL)
        {
            dal = DAL;
        }

        public int VoegLocatieToeMetID(string naam, string adres)
        {
            LocatieDTO dto = new LocatieDTO();
            dto.Naam = naam;
            dto.Adres = adres;
            return dal.VoegLocatieToeMetID(dto);
        }
    }
}
