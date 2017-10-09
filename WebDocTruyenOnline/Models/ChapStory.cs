namespace WebDocTruyenOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChapStory")]
    public partial class ChapStory
    {
        public long Id { get; set; }

        [Display(Name ="Tên truyện")]
        public long? StoryId { get; set; }
        [Required(ErrorMessage ="Bạn phải nhập chap")]
        public int Chap { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name ="Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Người tạo")]
        [StringLength(250)]
        public string CreateBy { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifyDate { get; set; }
        [Display(Name = "Người cập nhật")]
        [StringLength(250)]
        public string ModifyBy { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name ="Tên chap")]
        public string ChapName { get; set; }

        public virtual Story Story { get; set; }
    }
}
