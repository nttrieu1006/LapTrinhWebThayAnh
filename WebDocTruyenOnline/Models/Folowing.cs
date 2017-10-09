using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDocTruyenOnline.Models
{
    public class Folowing
    {
        public Story Story { get; set; }

        [Key]
        [Column(Order = 1)]
        public long StoryId { get; set; }

        public ApplicationUser Folower { get; set; }

        [Key]
        [Column(Order =2)]
        public string FolowerId { set; get; }
    }
}