using System;
using System.Collections.Generic;

namespace Livestock.DTO.SystemUsersDTOs
{
    public class SystemUsersDataTableDTO
    {
        public int CountAllRows { get; set; }
        public List<SystemUsersDTO> Data { get; set; }
    }
    public class SystemUsersDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string NameArabic { get; set; } = null!;
        public string NameEnglish { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal UserGroupId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastChangePassword { get; set; }
        public int CountAllRows { get; set; }
        public bool? IsActive { get; set; }

    }
    public class DataTableParmUserSysDTO
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string search { get; set; }
        public int USERGROUPID { get; set; }    
        public int USERBranch { get; set;}
    }
    public class GetUSER_GROUPIDDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    public class GetUserBranchDTO
    {
       
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    public class GetSysModuleDTO
    {

        public int Id { get; set; }
        public string Desc { get; set; }
       
    }
    public class GetCntMasterDTO
    {

        public long Id { get; set; }
        public string AccName { get; set; }

    }
    public class SystemUsersDetailsDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string NameArabic { get; set; } = null!;
        public string NameEnglish { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal UserGroupId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastChangePassword { get; set; }
        public int CountAllRows { get; set; }
        public bool? IsActive { get; set; }
    }
}
