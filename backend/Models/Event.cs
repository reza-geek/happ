namespace backend.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("Event")]
    public class Event
    {
        public Event()
        {
        }

        [Key]
        public int Event_ID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Event_Name { get; set; }

        //public ICollection<Catheter_event> Catheter_event { get; set; }
    }
}
