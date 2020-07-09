using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvCast.Entity.Entities
{
    [Table("casting", Schema = "public")]
    public class Casting
    {
        [Key, Column("id")]
        public long? Id { get; set; }
        [ForeignKey("show_id")]
        public Show Show { get; set; }
        [ForeignKey("person_id")]
        public Person Person { get; set; }
        [ForeignKey("character_id")]
        public Character Character { get; set; }
    }
}