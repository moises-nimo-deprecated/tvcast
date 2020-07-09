using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TvCast.Entity.Entities.Data;

namespace TvCast.Entity.Entities
{
    [Table("character", Schema = "public")]
    public class Character
    {
        [Key, Column("id")]
        public long? Id { get; set; }
        [Column("added")]
        public DateTime? Added => DateTime.Now;
        [Column("data", TypeName = "jsonb")]
            
        public CharacterData Data { get; set; }
    }
}