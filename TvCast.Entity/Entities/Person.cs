using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TvCast.Entity.Entities.Data;

namespace TvCast.Entity.Entities
{
    [Table("person", Schema = "public")]
    public class Person
    {
        [Key, Column("id")]
        public long? Id { get; set; }
        [Column("added")]
        public DateTime? Added => DateTime.Now;
        [Column("data", TypeName = "jsonb")]
        public PersonData Data { get; set; }
    }
}