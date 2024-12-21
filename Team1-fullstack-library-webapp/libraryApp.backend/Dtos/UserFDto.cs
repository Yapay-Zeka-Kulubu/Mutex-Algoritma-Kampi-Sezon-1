using Org.BouncyCastle.Asn1.Crmf;

namespace libraryApp.backend.Dtos
{
    public class UserFDto
    {
        public int userId { get; set; }
        public string fullname { get; set; }
        public string roleName { get; set;}
        public bool isPunished { get; set;}
    }
}
