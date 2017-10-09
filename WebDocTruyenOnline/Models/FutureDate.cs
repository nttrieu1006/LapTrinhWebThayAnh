using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebDocTruyenOnline.Models
{
    public class FutureDate:ValidationAttribute
    {
        public bool IsVaid(object value)
        {
            DateTime dateTime;
            var isVaid = DateTime.TryParseExact(Convert.ToString(value), "dd/MM/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime
                );
            return isVaid;
        }
    }
}