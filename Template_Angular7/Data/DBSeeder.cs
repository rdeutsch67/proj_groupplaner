using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Template_Angular7.Data
{
    public static class DBSeeder
    {
        #region Public Methods
        public static void Seed(ApplicationDbContext dbContext)
        {
            // Dummy-Benutzer erstellen
            if (!dbContext.Benutzer.Any()) CreateBenutzer(dbContext);

            // Dummy-Gruppen erstellen
            if (!dbContext.Gruppen.Any()) CreateGruppen(dbContext);
        }
        #endregion
        
        #region Seed Methods
        private static void CreateBenutzer(ApplicationDbContext dbContext)
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;

            // Create the "Admin" ApplicationUser account (if it doesn't exist already)
            var user_Admin = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "admin@gruppenverwaltung.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            // Insert the Admin user into the Database
            dbContext.Benutzer.Add(user_Admin);

#if DEBUG
            // Create some sample registered user accounts (if they don't exist already)
            var user_Ryan = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Ryan",
                Email = "ryan@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            var user_Solice = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Solice",
                Email = "solice@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            var user_Vodan = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Vodan",
                Email = "vodan@testmakerfree.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            // Insert sample registered users into the Database
            dbContext.Benutzer.AddRange(user_Ryan, user_Solice, user_Vodan);
#endif
            dbContext.SaveChanges();
        }
        
        private static void CreateGruppen(ApplicationDbContext dbContext)
        {
            // local variables
            DateTime createdDate = new DateTime(2017, 08, 08, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;

            // retrieve the admin user, which we'll use as default author.
            var authorId = dbContext.Benutzer
                .Where(u => u.UserName == "Admin")
                .FirstOrDefault()
                .Id;

            // erstelle die erste Demogruppe
            EntityEntry<Gruppe> e1 = dbContext.Gruppen.Add(new Gruppe()
            {
                UserId = authorId,
                Code = "Trogner Jassrunde",
                Beschreibung = "Jassrunde mit Trogner Mitglieder",
                Bezeichnung = @"Jassrunde, welche sich aus hardcore Trogner Jässler zusammensetzt.",
                //ViewCount = 2343,
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            });
            
#if DEBUG
            // noch weitere 4 Demogruppen erstellen
            var num = 4;
            for (int i = 2; i <= num; i++)
            {
                ErstelleBeispielGruppen(
                    dbContext,
                    i,
                    authorId,
                    createdDate.AddDays(-num));
            }
#endif
           
            
            // persist the changes on the Database
            dbContext.SaveChanges();
        }
        #endregion
        
        #region Utility Methods
        /// <summary>
        /// Erstellt Demogruppen und speichert sie auf der Datenbank
        /// </summary>
        /// <param name="userId">Ersteller-ID</param>
        /// <param name="id">Gruppen-ID</param>
        /// <param name="createdDate">CreatedDate</param>
        private static void ErstelleBeispielGruppen(
            ApplicationDbContext dbContext,
            int num,
            string authorId,
            //int viewCount,
            DateTime createdDate)
        {
            var gruppe = new Gruppe()
            {
                UserId = authorId,
                Code = String.Format("Gruppe {0} Code", num),
                Bezeichnung = String.Format("Beispielgruppe {0}.", num),
                Beschreibung = "Dies ist eine automatisch von DBSeeder erstellte Gruppe.",
                //ViewCount = viewCount,
                CreatedDate = createdDate,
                LastModifiedDate = createdDate
            };
            dbContext.Gruppen.Add(gruppe);
            dbContext.SaveChanges();
            
        }
        #endregion
    }
}