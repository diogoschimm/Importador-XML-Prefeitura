using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfrontadorNFSe
{
    public static class StringExtensions
    {
        public static DateTime ToDateTime(this string strIn)
        {
            //2019-10-01T00:00:00
            //01234567890123456789
            if (strIn.Length >= 10)
                return DateTime.Parse(strIn.Substring(8, 2) + "/" + strIn.Substring(5, 2) + "/" + strIn.Substring(0, 4));

            return DateTime.Now.AddDays(100);
        }
    }

}
