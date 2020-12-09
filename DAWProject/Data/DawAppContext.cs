using DAWProject.Models;
using DAWProject.Models.Relations.Many_to_Many;
using DAWProject.Models.Relations.One_to_Many;
using DAWProject.Models.Relations.One_to_One;

using Microsoft.EntityFrameworkCore;

namespace DAWProject.Data
{
    public class DawAppContext : DbContext
    {
        public DbSet<DataBaseModel> DataBaseModels { get; set; }


        // One to Many
        public DbSet<Models.Relations.One_to_Many.Model1> Models1 { get; set; }
        public DbSet<Models.Relations.One_to_Many.Model2> Models2 { get; set; }


        // One to One
        public DbSet<Model5> Models5 { get; set; }
        public DbSet<Model6> Models6 { get; set; }

        // Many to Many
        public DbSet<Model3> Models3 { get; set; }
        public DbSet<Model4> Models4 { get; set; }
        public DbSet<ModelsRelation> ModelsRelations { get; set; }


        public DbSet<Models.Model1> SimpleModels1 { get; set; }
        public DbSet<Models.Model2> SimpleModels2 { get; set; }

        public DawAppContext(DbContextOptions<DawAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One to Many

            builder.Entity<Models.Relations.One_to_Many.Model1>()
                .HasMany(x => x.Models2)
                .WithOne(y => y.Model1);
            // To prevent optional relation
            //.IsRequired();

            // Different way to declare relation
            //builder.Entity<Model2>()
            //.HasOne(x => x.Model1)
            //.WithMany(y => y.Models2);

            // One to One
            builder.Entity<Model5>()
                .HasOne(x => x.Model6)
                .WithOne(y => y.Model5)
                .HasForeignKey<Model6>
                (z => z.Model5Id);

            // Many to Many
            builder.Entity<ModelsRelation>()
                .HasKey(mr => 
                new { mr.Model3Id, mr.Model4Id });

            builder.Entity<ModelsRelation>()
                .HasOne<Model3>(x => x.Model3)
                .WithMany(y => y.ModelRelations)
                .HasForeignKey(z => z.Model3Id);

            builder.Entity<ModelsRelation>()
                .HasOne<Model4>(x => x.Model4)
                .WithMany(y => y.ModelRelations)
                .HasForeignKey(z => z.Model4Id);


            builder.Entity<Models.Model1>()
           .HasMany(x => x.Models2)
           .WithOne(x => x.Model1);

            base.OnModelCreating(builder);
        }

    }
}
