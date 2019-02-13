using System;
using System.ComponentModel.DataAnnotations;


namespace planner09.Models
{
    public class planner
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
    }
}