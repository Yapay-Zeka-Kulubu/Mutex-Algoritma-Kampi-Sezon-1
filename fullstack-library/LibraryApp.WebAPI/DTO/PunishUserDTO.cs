using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class PunishUserDTO
    {
        public int UserId { get; set; }
        public int PunisherId { get; set; }
        public bool IsPunished { get; set; }
        public float FineAmount { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}