using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template_Angular7.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Template_Angular7.Data;
using Template_Angular7.Controllers;
using Mapster;

namespace Template_Angular7.Controllers
{
    [Route("api/[controller]")]
    public class GruppenController : BaseApiController
    /*public class GruppenController : Controller*/
    {
        #region Constructor
        public GruppenController(ApplicationDbContext context): base(context) { }
        #endregion Constructor
        
        #region RESTful conventions methods
        /// <summary>
        /// GET: api/gruppen/{id}
        /// Retrieves the Quiz with the given {id}
        /// </summary>
        /// <param name="id">The ID of an existing Quiz</param>
        /// <returns>the Quiz with the given {id}</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var gruppe = DbContext.Gruppen.Where(i => i.Id == id).FirstOrDefault();
            var gruppe = DbContext.Gruppen.FirstOrDefault(i => i.Id == id);
            return new JsonResult(
                gruppe.Adapt<GruppenViewModel>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
        /// <summary>
        /// neue Gruppe in die DB eintragen
        /// </summary>
        /// <param name="m">The GruppenViewModel containing the data to insert</param>
        [HttpPut]
        public IActionResult Put(GruppenViewModel m)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gruppe anhand der {id} editieren
        /// </summary>
        /// <param name="m">The GruppenViewModel containing the data to update</param>
        [HttpPost]
        public IActionResult Post(GruppenViewModel m)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Löscht eine Gruppen über die {id} auf der DB
        /// </summary>
        /// <param name="id">The ID of an existing Test</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        
        // GET api/gruppen/alle
        [HttpGet("Alle/{num?}")]
        public IActionResult Alle(int num = 10)
        {
            
            var myGruppen = DbContext.Gruppen
                .OrderByDescending(q => q.CreatedDate)
                .Take(num)
                .ToArray();
            return new JsonResult(
                myGruppen.Adapt<GruppenViewModel[]>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}
