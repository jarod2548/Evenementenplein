using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class LocatieDTO
    {
        public int ID {  get;  set; }
        public string Naam { get;  set; } = string.Empty;
        public string Adres { get;  set; } = string.Empty;

    }
}
