using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TvCast.Entity.Entities.Data;

namespace TvCast.Entity.Entities
{
    [Table("show", Schema = "public")]
    public class Show
    {
        [Key,Column("id")]
        public long? Id { get; set; }
        [Column("added")]
        public DateTime? Added => DateTime.Now;
        [Column("data", TypeName = "jsonb")]
        public ShowData Data { get; set; }
        
        public IEnumerable<Casting> Castings { get; set; }
    }
}