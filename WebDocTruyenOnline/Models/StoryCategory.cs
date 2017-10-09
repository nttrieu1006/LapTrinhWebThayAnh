namespace WebDocTruyenOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoryCategory")]
    public partial class StoryCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StoryCategory()
        {
            Stories = new HashSet<Story>();
        }

        public long Id { get; set; }
        [Display(Name="Tên danh mục")]
        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public int? DisplayOrder { get; set; }

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

        public bool ShowOnHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Story> Stories { get; set; }
    }
}
