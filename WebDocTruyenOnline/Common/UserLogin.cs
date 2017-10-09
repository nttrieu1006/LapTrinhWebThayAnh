using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDocTruyenOnline.Common
{
    [Serializable]
    public class UserLogin
    {
        [Required]
        public string Email { set; get; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
    }
}