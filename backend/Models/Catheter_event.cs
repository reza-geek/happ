using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace backend.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Table("Catheter_event")]
    public class Catheter_event
    {
        [Key]
        public long CatheterisationEvent_ID { get; set; }
        //public long Catheterisation_ID { get; set; }
        
        //public int Event_ID { get; set; }
        public string Event_Desc { get; set; }
        public string Event_Date { get; set; }

        public Catheterisation Catheterisation { get; set; }
        public Event Event { get; set; }
    }
}
