using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livestock.DTO.MenuDTOs
{
    public class MenuDTO
    {
        public MenuDTO()
        {
            ListMenu = new List<MenuDTO>();
        }
        public int Id { get; set; }
        public virtual string ModuleName { get; set; }
        public virtual string Name_En { get; set; }
        public virtual string Name_Ar { get; set; }
        public virtual string ActionLink { get; set; }
        public virtual string ControllerName { get; set; }
        public virtual string ActionViewName { get; set; }
        public virtual bool IsActive { get; set; }
        public decimal? ModuleId { get; set; }
        public string? Menuorder { get; set; }
        public decimal? PerantId { get; set; }

        public virtual List<MenuDTO> ListMenu { get; set; }
    }

}
