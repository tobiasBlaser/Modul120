using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Stadt
    {
        #region Datenbankschicht
        [Key]
        public Int64 StadtId { get; set; }
        public String StadtName { get; set; }
        public Int64 Einwohnerzahl { get; set; }
        public Int64 Flaeche { get; set; }
        public Boolean IsHauptstadt { get; set; }
        public Int64 LandId { get; set; }
        public Land Land { get; set; }
        #endregion
        #region Applikationsschicht
        public Stadt() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Data.Stadt> LesenAlle()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Stadt.Include(x => x.Land) select record).ToList();
            }
        }
        public static Data.Stadt LesenID(Int64 StadtId)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Stadt.Include(x => x.Land) where record.StadtId == StadtId select record).FirstOrDefault();
            }
        }
        public static List<Data.Stadt> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Stadt.Include(x => x.Land) where record.StadtName == suchbegriff select record).ToList();
            }
        }
        public static List<Data.Stadt> LesenAttributWie(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Stadt.Include(x => x.Land) where record.StadtName.Contains(suchbegriff) select record).ToList();
            }
        }
        public static List<Data.Stadt> LesenFremdschluesselGleich(Data.Land suchschluessel)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Stadt.Include(x => x.Land) where record.Land == suchschluessel select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.StadtName == null || this.StadtName == "") this.StadtName = "leer";
            // Option mit Fehler statt Default Value
            // if (Stadt.TextAttribut == null) throw new Exception("Null ist ungültig");
            if (this.Einwohnerzahl == null) this.Einwohnerzahl = 0;
            using (var context = new Data.Context())
            {
                context.Stadt.Add(this);
                //TODO Check ob mit null möglich, sonst throw Ex
                if (this.Land != null) context.Land.Attach(this.Land);
                context.SaveChanges();
                return this.StadtId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                this.Land = null;
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return this.StadtId;
            }
        }
        public void Loeschen()
        {
            using (var context = new Data.Context())
            {
                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public override string ToString()
        {
            return StadtId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
