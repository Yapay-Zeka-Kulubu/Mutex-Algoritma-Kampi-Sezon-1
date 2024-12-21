using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class ReportDTO
    {
        public int TotalUserCount { get; set; }
        public int TotalBookCount { get; set; }
        public List<KeyValuePair<string,int>> UsersPerRole { get; set; } = new();
        public List<KeyValuePair<string,int>> MostBorrowedBooks { get; set; } = new();
        public List<KeyValuePair<string,int>> MostScoredMembers { get; set; } = new();
        public List<KeyValuePair<string,int>> MostBorrowers { get; set; } = new();
    }
}