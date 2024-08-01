using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livestock.DTO.MenuDTOs;

namespace Livestock.DTO.ModulesDTOs
{
    public class ModulesDTO
    {
        public virtual int? Id { get; set; }
        public virtual string Name_Ar { get; set; }
        public virtual string Name_En { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual List<MenuDTO> Menus { get; set; }
    }
}
