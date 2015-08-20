using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVW.Data
{
    public class MVWDataBase : DbContext
    {
        public MVWDataBase()
            : base("MVWDataBase")
        {

        }
        public DbSet<WordEntity> Word { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WordEntity>().ToTable("dbo.Word");

        }


    }

    public abstract class BaseEntity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        public DateTime CreateUtc { get; set; }

        public DateTime ModifyUtc { get; set; }

        public string CreateUser { get; set; }



    }

    public class WordEntity : BaseEntity
    {
        public string FromWord { get; set; }
        public string ToWord { get; set; }
        public int KnowTimes { get; set; }

        public bool Closed { get; set; }

        public DateTime? CloseUtc { get; set; }

        public bool Star { get; set; }
        public DateTime? StarUtc { get; set; }

    }
}
