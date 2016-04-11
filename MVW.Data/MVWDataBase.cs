using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVW.Data
{
    //public class MVWDataBase : DbContext
    //{
    //    public MVWDataBase()
    //        : base("MVWDataBase")
    //    {

    //    }
    //    public DbSet<WordEntity> Word { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //        modelBuilder.Entity<WordEntity>().ToTable("dbo.Word");

    //    }


    //}

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

    public class MVWJsonDataBase
    {
        public string Folder { get; set; }
        public string WordFile { get; set; }

        public MVWJsonDataBase(string folder)
        {
            this.Folder = folder;
            InitWord(folder);
        }

        private void InitWord(string folder)
        {
            WordFile = Path.Combine(folder, "Word.json");
            if (!File.Exists(WordFile))
            {
                File.Create(WordFile).Dispose();
                System.Threading.Thread.Sleep(1000);
            }
            Word = FileToObject<List<WordEntity>>(WordFile);
            if (Word == null)
                Word = new List<WordEntity>();
        }

        public List<WordEntity> Word { get; set; }

        public void SaveChanges()
        {
            ObjectToFile(Word, WordFile);
        }

        /// <summary>
        /// 序列化物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private void ObjectToFile<T>(T value, string file)
        {

            using (StreamWriter sw = new StreamWriter(file))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.NullValueHandling = NullValueHandling.Ignore;//2015/05/04
                    serializer.Serialize(writer, value);
                }
            }

        }

        private T FileToObject<T>(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(reader);
                }
            }
        }
    }
}
