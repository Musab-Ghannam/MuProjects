//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mainMasterpiesce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public patient()
        {
            this.appointments = new HashSet<appointment>();
            this.feedbacks = new HashSet<feedback>();
            this.transactionspatients = new HashSet<transactionspatient>();
            this.doctors = new HashSet<doctor>();
        }
    
        public int PatiantId { get; set; }
        public string Id { get; set; }
        public string locationpatent { get; set; }
        public string picpatient { get; set; }
        public string patientName { get; set; }
        public string patientemail { get; set; }
        public Nullable<System.DateTime> startedate { get; set; }
        public Nullable<double> wallet { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string locationdetails { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointments { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transactionspatient> transactionspatients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doctor> doctors { get; set; }
    }
}
