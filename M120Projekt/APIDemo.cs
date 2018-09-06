using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA (lange Syntax)
            Data.Stadt klasseA1 = new Data.Stadt();
            klasseA1.StadtName = "Schweiz";
            klasseA1.Einwohnerzahl = 150000;
            klasseA1.Flaeche = 51;
            klasseA1.IsHauptstadt = true;
            klasseA1.Land = Data.Land.LesenAttributWie("Schweiz").FirstOrDefault();
            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Stadt klasseA in Data.Stadt.LesenAlle())
            {
                Debug.Print("StadtId:" + klasseA.StadtId + " Name:" + klasseA.StadtName + " Artikelgruppe:" + klasseA.Land.LandName);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Stadt klasseA1 = Data.Stadt.LesenID(1);
            klasseA1.StadtName = "Artikel 1 nach Update";
            klasseA1.LandId = 2;  // Wichtig: Fremdschlüssel muss über Id aktualisiert werden!
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Stadt.LesenID(1).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
        #region KlasseB
        // Create
        public static void DemoBCreate()
        {
            Debug.Print("--- DemoBCreate ---");
            // KlasseB (kurze Syntax)
            Data.Land klasseB1 = new Data.Land { LandName = "Schweiz", Einwohnerzahl = 8000000, Gruendungsjahr = DateTime.Today.AddDays(-1), Flaeche = 40000, Hauptsprache = "Deutsch"};
            Int64 klasseB1Id = klasseB1.Erstellen();
            Debug.Print("Gruppe erstellt mit Id:" + klasseB1Id);
            Data.Land klasseB2 = new Data.Land { LandName = "Deutschland", Einwohnerzahl = 26000000, Gruendungsjahr = DateTime.Today, Flaeche = 360000, Hauptsprache = "Deutsch"};
            Int64 klasseB2Id = klasseB2.Erstellen();
            Debug.Print("Gruppe erstellt mit Id:" + klasseB2Id);
        }
        // Read
        public static void DemoBRead()
        {
            Debug.Print("--- DemoBRead ---");
            // Demo liest 1 Objekt
            Data.Land klasseB = Data.Land.LesenAttributGleich("Schweiz").FirstOrDefault();
            Debug.Print("Auslesen einzelne Gruppe mit Name: " + klasseB.LandName + " Datum" + klasseB.Gruendungsjahr.ToString("dd.MM.yyyy"));
            // Liste auslesen
            foreach(Data.Stadt klasseA in klasseB.Stadt)
            {
                Debug.Print("Artikelgruppe: " + klasseB.LandName + " enthält Artikel:" + klasseA.StadtName);
            }
        }
        // Update
        public static void DemoBUpdate()
        {
            Debug.Print("--- DemoBUpdate ---");
            Data.Land klasseB = Data.Land.LesenID(1);
            klasseB.LandName = "Artikelgruppe 2 nach Update";
            klasseB.Aktualisieren();
            Debug.Print("Gruppe mit Name 'Artikelgruppe 1' verändert");
        }
        // Delete
        public static void DemoBDelete()
        {
            Debug.Print("--- DemoBDelete ---");
            // Achtung! Referentielle Integrität darf nicht verletzt werden!
            try
            {
                Data.Land klasseB = Data.Land.LesenID(1);
                klasseB.Loeschen();
                Debug.Print("Gruppe mit Id 1 gelöscht");
            } catch (Exception ex)
            {
                Debug.Print("Fehler beim Löschen:" + ex.Message);
            }
        }
        #endregion
    }
}
