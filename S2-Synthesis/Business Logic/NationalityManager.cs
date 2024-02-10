using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Business_Logic
{
   public class NationalityManager
    {
        public  List<String> CountryList()
        {
            List<string> countries = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach(CultureInfo c in cultures)
            {
                RegionInfo info = new RegionInfo(c.Name);
                if (!(countries.Contains(info.EnglishName))) countries.Add(info.EnglishName);
            }
            countries.ToArray();
            countries.Sort();
            return countries;
        }
    }
}
