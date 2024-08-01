using System;
using System.Collections.Generic;

namespace Livestock.DTO.SystemUserGroupsDTOs
{
    public class SystemUserGroupsDataTableDTO
    {
        public int CountAllRows { get; set; }
        public List<SystemUserGroupsDTO> Data { get; set; }
    }
    public class SystemUserGroupsDTO
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
    public class SystemUserGroupsDetailsDTO
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SystemFunctions { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedUser { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int IsAmlGroup { get; set; }
        public string Dashboards { get; set; }
    }
}
