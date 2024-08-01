using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace livestockProject.Helper.Localizer
{
    public class CultureConstraint : IRouteConstraint
    {
        private readonly string defaultCulture;
        private readonly string pattern;

        public CultureConstraint(string defaultCulture, string pattern)
        {
            this.defaultCulture = defaultCulture;
            this.pattern = pattern;
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.UrlGeneration &&
                            this.defaultCulture.Equals(values[routeKey]))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch((string)values[routeKey], "^" + pattern + "$");
            }
        }
    }
}