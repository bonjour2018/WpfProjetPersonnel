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
    
    public partial class Chambre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chambre()
        {
            this.Lits = new HashSet<Lit>();
            this.TypeChambres = new HashSet<TypeChambre>();
        }
    
        public string idChambre { get; set; }
        public string prefixe { get; set; }
        public int idType { get; set; }
    
        public virtual Departement1 Departement1 { get; set; }
        public virtual TypeChambre TypeChambre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lit> Lits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeChambre> TypeChambres { get; set; }
    }
}
