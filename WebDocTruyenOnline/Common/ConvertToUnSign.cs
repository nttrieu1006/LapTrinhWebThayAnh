using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebDocTruyenOnline.Common
{
    public static class ConvertToUnSign
    {
        public static string convertToUnSign(string s)
        {
            s = s.ToLower();
            char[] str = { ' ', '+', '%', '@', '#', '!', '$', '^', '&', '*', '(', ')', '_', '=' };
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            s = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            foreach (char item in str)
            {
                s = s.Replace(item, Convert.ToChar("-"));
            }

            s = s.Replace(".", "");
            return s;
        }
    }
}