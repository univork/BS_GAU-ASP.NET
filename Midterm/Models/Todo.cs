namespace Midterm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Todo")]
    public partial class Todo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Todo()
        {
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Title cannot be longer that 100 characters")]
        [Required(ErrorMessage = "Todo Title is Mandatory")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Title cannot be longer that 500 characters")]
        public string Description { get; set; }

        public bool Completed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
