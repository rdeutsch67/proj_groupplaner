using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template_Angular7.ViewModels;
using System.Collections.Generic;

namespace Template_Angular7.Controllers
{
    [Route("api/[controller]")]
    public class GruppenController : Controller
    {
        // GET api/gruppen/alle
        [HttpGet("Alle/{num}")]
        public IActionResult Alle(int num = 10)
        {
            var sampleGruppen = new List<GruppenViewModel>();
            
            // erster Beispieldatensatz
            sampleGruppen.Add(new GruppenViewModel()
            {
                Id = 1,
                IdTeilnehmer = 1,
                Code = "jassen",
                Bezeichnung = "Gruppe für das Verwalten der gemeinsamen Jassabende.",
                Hinweis = "Jazzgruppe",
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
                    IdTeilnehmer = 1,
                    Code = String.Format("code_", i),
                    Bezeichnung = String.Format("Beispielgruppe {0}", i),
                    Hinweis = String.Format("Hinweis {0}", i),
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
