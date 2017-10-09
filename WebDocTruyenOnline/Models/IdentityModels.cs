using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WebDocTruyenOnline.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Avartar { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<ChapStory> ChapStories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<StoryCategory> StoryCategories { get; set; }
        public virtual DbSet<StoryType> StoryTypes { get; set; }

        public virtual DbSet<Folowing> Folowings { set; get; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Folowing>()
                .HasRequired(a => a.Story)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChapStory>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<ChapStory>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChapStory>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.MenuType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Slide>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Story>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.Descirption)
                .IsFixedLength();

            modelBuilder.Entity<Story>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Story>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<StoryCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<StoryCategory>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<StoryCategory>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<StoryCategory>()
                .HasMany(e => e.Stories)
                .WithOptional(e => e.StoryCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<StoryType>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<StoryType>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<StoryType>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<StoryType>()
                .HasMany(e => e.Stories)
                .WithOptional(e => e.StoryType)
                .HasForeignKey(e => e.TypeId);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}