namespace EltonEsame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registry")]
    public partial class Registry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registry()
        {
            Tickets = new HashSet<Ticket>();
            Tickets1 = new HashSet<Ticket>();
        }

        [Key]
        public int IdRegistry { get; set; }

        [StringLength(50)]
        public string FirstLastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? PhoneNumber { get; set; }

        [StringLength(50)]
        public string FullAddress { get; set; }

        public bool? ClientFlag { get; set; }

        public bool? InternalFlag { get; set; }

        public bool? SupplierFlag { get; set; }

        [StringLength(4)]
        public string RegistryCode { get; set; }

        [StringLength(10)]
        public string Username { get; set; }

        [StringLength(25)]
        public string PassWordField { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets1 { get; set; }
    }
}
