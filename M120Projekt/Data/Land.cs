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
    public class Land
    {
        #region Datenbankschicht
        [Key]
        public Int64 LandId { get; set; }
        public String LandName { get; set; }
        public DateTime Gruendungsjahr { get; set; }
        public Int64 Flaeche { get; set; }
        public Int64 Einwohnerzahl { get; set; }
        public String Hauptsprache { get; set; }
        public ICollection<Stadt> Stadt { get; set; }
        #endregion
        #region Applikationsschicht
        public Land() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Data.Land> LesenAlle()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Land.Include(x => x.Stadt) select record).ToList();
            }
        }
        public static Data.Land LesenID(Int64 LandId)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Land.Include(x => x.Stadt) where record.LandId == LandId select record).FirstOrDefault();
            }
        }
        public static List<Data.Land> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                var Landquery = (from record in context.Land.Include(x => x.Stadt) where record.LandName == suchbegriff select record).ToList();
                return Landquery;
            }
        }
        public static List<Data.Land> LesenAttributWie(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Land.Include(x => x.Stadt) where record.LandName.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.LandName == null || this.LandName == "") this.LandName = "leer";
            // Option mit Fehler statt Default Value
            // if (Land.TextAttribut == null) throw new Exception("Null ist ungültig");
            using (var context = new Data.Context())
            {
                context.Land.Add(this);
                context.SaveChanges();
                return this.LandId;
            }
        }
        public void Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
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
            return LandId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
