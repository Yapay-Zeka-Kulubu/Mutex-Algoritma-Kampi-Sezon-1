using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryApp.backend.Dtos
{
    public class cezaVerdto
    {
        public int userId { get; set; }
        public int cezaVerenId { get; set; }
        public string mesajBaslik { get; set; }
        public string mesajIcerik { get; set; }
    }
}