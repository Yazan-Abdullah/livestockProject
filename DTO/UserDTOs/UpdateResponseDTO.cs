using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livestock.DTO.AccountDTOs;

namespace Livestock.DTO.UserDTOs
{
    public class UpdateResponseDTO
    {
        public UpdateResponseDTO()
        {
            UserInfo = new UserInfo();
        }
        public bool success { get; set; }
        public string message { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
