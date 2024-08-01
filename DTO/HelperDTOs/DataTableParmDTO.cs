using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livestock.DTO.HelperDTOs
{
    public class DataTableParmDTO
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string search { get; set; }
    }
}
