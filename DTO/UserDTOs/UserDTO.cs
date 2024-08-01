using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livestock.DTO.UserDTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string NameEnglish { get; set; }
        public string NameArabic { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
