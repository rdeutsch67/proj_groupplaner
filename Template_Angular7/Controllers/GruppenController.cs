using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template_Angular7.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Template_Angular7.Data;
using Template_Angular7.Controllers;

namespace Template_Angular7.Controllers
{
    [Route("api/[controller]")]
    public class GruppenController : BaseApiController
    /*public class GruppenController : Controller*/
    {
        #region Constructor
        public GruppenController(ApplicationDbContext context): base(context) { }
        #endregion Constructor
        
        // GET api/gruppen/alle
        [HttpGet("Alle/{num?}")]
        public IActionResult Alle(int num = 10)
        {
            var sampleGruppen = new List<GruppenViewModel>();
            
            // erster Beispieldatensatz
            sampleGruppen.Add(new GruppenViewModel()
            {
                Id = 1,
                Code = "jassen",
                Bezeichnung = "Gruppe für das Verwalten der gemeinsamen Jassabende.",
                Beschreibung = "Jazzgruppe",
                Aktiv = true,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });
            
            // weitere Beispieldaten
            for (int i = 2; i <= num; i++)
            {
                sampleGruppen.Add(new GruppenViewModel()
                {
                    Id = i,
                    Code = String.Format("code_", i),
                    Bezeichnung = String.Format("Beispielgruppe {0}", i),
                    Beschreibung = String.Format("Hinweis {0}", i),
                    Aktiv = false,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }
            
            // output the result in JSON format
            return new JsonResult(
                sampleGruppen,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}
