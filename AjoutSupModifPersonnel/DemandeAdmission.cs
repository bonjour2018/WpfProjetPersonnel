//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AjoutSupModifPersonnel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DemandeAdmission
    {
        public int idMedecin { get; set; }
        public int idPatient { get; set; }
        public int idPrepose { get; set; }
        public string idLit { get; set; }
        public Nullable<int> idCommo { get; set; }
        public Nullable<System.DateTime> dateAdmiss { get; set; }
        public Nullable<System.DateTime> dateConge { get; set; }
    
        public virtual CommoditeSup CommoditeSup { get; set; }
        public virtual Lit Lit { get; set; }
        public virtual Medecin Medecin { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Prepose Prepose { get; set; }
    }
}