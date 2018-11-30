using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
namespace Template_Angular7.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class GruppenViewModel
    {
        #region Constructor
        public GruppenViewModel()
        {
        }
        #endregion
        #region Properties
        public int Id { get; set; }
        public int IdTeilnehmer { get; set; }          // Gruppenleiter (Gruppen-Admin)
        public string Code { get; set; }               
        public string Bezeichnung { get; set; }
        public string Hinweis { get; set; }
        public string Aktiv { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        #endregion
    }
}