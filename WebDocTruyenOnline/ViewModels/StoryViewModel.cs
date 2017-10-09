using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.ViewModels
{
    public class StoryViewModel
    {
        public IEnumerable<Story> StoryFolow { get; set; }
        public bool ShowAction { get; set; }
    }
}