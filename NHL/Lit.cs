//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lit()
        {
            this.DemandeAdmissions = new HashSet<DemandeAdmission>();
        }
    
        public string idLit { get; set; }
        public string idChambre { get; set; }
        public Nullable<bool> dispo { get; set; }
    
        public virtual Chambre Chambre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemandeAdmission> DemandeAdmissions { get; set; }
    }
}
