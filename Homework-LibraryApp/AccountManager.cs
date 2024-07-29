using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    public static class AccountManager
    {
        private static Human? _human;
        public static Human? CurrentHuman => _human;
        public static bool IsLoggedIn => _human != null;

        public static bool Login(int id, string password)
        {
            if (IsLoggedIn) return false;

            var human = Library.HumanRepo.MyList.FirstOrDefault(a => a.Id == id);

            if (human == null) return false;

            if (human.Password != password) return false;

            _human = human;
            return true;
        }

        public static void Logout()
        {
            if (!IsLoggedIn) return;

            _human = null;
        }

        public static void Register(Human human)
        {
             Library.HumanRepo.MyList.Add(human);
        }

        public static bool ChangePassword(string newPassword)
        {
            if (!IsLoggedIn) return false;

            _human!.Password = newPassword;
            return true;
        }
    }
}