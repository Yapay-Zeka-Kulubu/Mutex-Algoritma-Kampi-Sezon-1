using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Data.Entity
{
    public class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Value { get; set; }
    }
}