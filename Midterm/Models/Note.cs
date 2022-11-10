namespace Midterm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Note")]
    public partial class Note
    {
        public int Id { get; set; }

        [StringLength(400)]
        public string TextContent { get; set; }

        public int? TodoId { get; set; }

        public virtual Todo Todo { get; set; }
    }
}
