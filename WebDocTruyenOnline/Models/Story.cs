namespace WebDocTruyenOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebDocTruyenOnline.Common;

    [Table("Story")]
    public partial class Story
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Story()
        {
            ChapStories = new HashSet<ChapStory>();
        }

        public long Id { get; set; }

        [Display(Name="Tên truyện")]
        [Required(ErrorMessage = ErrorMessage.Required)]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Descirption { get; set; }

        public long? AuthorId { get; set; }

        public long? TypeId { get; set; }

        public long? CategoryId { get; set; }

        [Display(Name="Ảnh bìa")]
        [StringLength(250)]
        public string Image { get; set; }

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

        [Display(Name="Lượt xem")]
        public int Views { get; set; }

        public DateTime? TopHot { get; set; }

        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChapStory> ChapStories { get; set; }

        public virtual StoryCategory StoryCategory { get; set; }

        public virtual StoryType StoryType { get; set; }
    }
}
