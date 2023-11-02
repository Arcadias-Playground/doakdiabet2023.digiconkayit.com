using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ModelBase
{
    [Table("KatilimciTablosu")]
    public abstract class KatilimciTablosuModelBase
    {
        [Key]
        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(36, ErrorMessage = "UzunlukUyari")]
        [Column("KatilimciID", Order = 0)]
        public virtual int KatilimciID { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("AdSoyad", Order = 1)]
        public virtual string AdSoyad { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("TCNo", Order = 2)]
        public virtual string TCNo { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [EmailAddress(ErrorMessage = "GecersizUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("ePosta", Order = 3)]
        public virtual string ePosta { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Telefon", Order = 4)]
        public virtual string Telefon { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("SicilNo", Order = 5)]
        public virtual string SicilNo { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Branþ", Order = 6)]
        public virtual string Branþ { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Meslek", Order = 7)]
        public virtual string Meslek { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Unvan", Order = 8)]
        public virtual string Unvan { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Hastane", Order = 9)]
        public virtual string Hastane { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Sehir", Order = 8)]
        public virtual string Sehir { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Ilce", Order = 9)]
        public virtual string Ilce { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("DogumTarihi", Order = 10)]
        public virtual DateTime DogumTarihi { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("KvkkOnay", Order = 11)]
        public virtual bool KvkkOnay { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
        [Column("GuncellenmeTarihi", Order = 12)]
        public virtual DateTime GuncellenmeTarihi { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
        [Column("EklenmeTarihi", Order = 13)]
        public virtual DateTime EklenmeTarihi { get; set; }



        public static int OzellikSayisi
        {
            get
            {
                return
                    typeof(KatilimciTablosuModelBase).GetProperties().Count(x => !x.GetAccessors()[0].IsStatic);
            }
        }

        public static string SQLSutunSorgusu
        {
            get
            {
                return
                    string.Join(", ", typeof(KatilimciTablosuModelBase).GetProperties().Where(x => !x.GetAccessors()[0].IsStatic).OrderBy(x => (x.GetCustomAttributes(typeof(ColumnAttribute), true).First() as ColumnAttribute).Order).Select(x => $"[KatilimciTablosu].[{x.Name}]"));
            }
        }

        public virtual string BaseJsonModel()
        {
            return
                JsonConvert.SerializeObject(this);
        }

    }
}