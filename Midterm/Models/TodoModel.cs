using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Midterm.Models
{
    public partial class TodoModel : DbContext
    {
        public TodoModel()
            : base("name=TodoModelContext")
        {
        }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Todo> Todoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
