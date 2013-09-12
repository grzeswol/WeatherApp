using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WeatherApp
{
    public class City
    {
        private readonly string _cityName;
        private readonly Country _country;
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public City(string cityName, Country country)
        {
            _cityName = cityName;
            _country = country;
            SetLatitudeAndLongitude();
        }

        private void SetLatitudeAndLongitude()
        {
            string path = GetURLForGivenCity(_cityName, _country);
            string sourceCode = GetSourceCode(path);

            try
            {
                List<string> coords = GetCoords(sourceCode).Split(',').ToList();
                Latitude = coords[0];
                Longitude = coords[1];
            }
            catch (ArgumentException)
            {
                Latitude = "";
                Longitude = "";
                throw;
            }
        }

        public string RemoveDiacritics(string input)
        {
            string stFormD = input.Trim().Normalize(NormalizationForm.FormD);
            int len = stFormD.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[i]);
                }
            }
            sb.Replace('ł', 'l');
            sb.Replace('Ł', 'L');
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public string GetURLForGivenCity(string city, Country country)
        {
            string cityNormalized = RemoveDiacritics(city).Replace(' ', '+');
            string countryNormalized = country.ToString();
            return
                string.Format(
                    "http://www.geody.com/geolook.php?world=terra&map=col&q={0}%2C+{1}&subm1=submit", cityNormalized, countryNormalized);
        }

        public string GetSourceCode(string path)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(path);
            }
        }

        public string GetBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int start = strSource.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
                int end = strSource.IndexOf(strEnd, start, StringComparison.Ordinal);
                return strSource.Substring(start, end - start);
            }
            return "";
        }

        public string GetCoords(string webPageSourceCode)
        {
            string result = GetBetween(webPageSourceCode, "Coords:", @""">");
            if (result == "")
            {
                throw new ArgumentException("Can't find the city!");
            }
            return result;
        }

        public string GetCityName()
        {
            return _cityName;
        }
    }
}