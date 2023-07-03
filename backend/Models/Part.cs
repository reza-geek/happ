namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Part")]
    public class Part
    {
        [Key]
        public int Part_ID { get; set; }
        [Required]
        public string Part_Name { get; set; }
        public string Comment { get; set; }

        //public virtual ICollection<Reception> Reception { get; set; }
    }
}
