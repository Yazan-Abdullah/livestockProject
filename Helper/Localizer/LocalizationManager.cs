using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace livestockProject/*.Helpers.Localizer*/
{
    public static class LocalizationManager
    {
        public static string GetString(string name)
        {
            try
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "/localized-strings.json";
                List<LocalizedString> dictionary = JsonConvert.DeserializeObject<List<LocalizedString>>(File.ReadAllText(filepath));
                var value = dictionary.FirstOrDefault(l => l.Key.ToLower() == name.ToLower());
                return value == null ? name : value.Values[CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower()] == "" ? name : value.Values[CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower()];
            }
            catch (Exception ex)
            {
                return name;
            }
        }
    }
}