using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class PublishBookDTO
    {
        public int RequestId { get; set; }
        public bool IsApproved { get; set; }
        public int ManagerId { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}