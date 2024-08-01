using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livestockProject.Models;

namespace livestockProject.Helper
{
    public class SessionManager
    {
        public IHttpContextAccessor _httpContextAccessor;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public SystemUser GetSessionUserInfo
        {
            get
            {                
                SystemUser userInfo = null;
                if (_httpContextAccessor.HttpContext.Session.GetString("UserInfo") != null)
                {
                    var userInfoConverter = JsonConvert.DeserializeObject<SystemUser>(_httpContextAccessor.HttpContext.Session.GetString("UserInfo"));
                    userInfo = userInfoConverter;
                    return userInfo;
                }

                //store the object in session if not already stored
                if (userInfo == null)
                    _httpContextAccessor.HttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(new SystemUser()));

                //return the object from session
                return new SystemUser();
            }
        }
        public SystemUser SetSessionUserInfo
        {
            set
            {
                _httpContextAccessor.HttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(value));
            }
        }
    }
}
