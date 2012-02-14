using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutoGreeter.Models
{
    public abstract class UserOwnedEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Greeting : UserOwnedEntityBase
    {
        public string GreetingText { get; set; }
        public virtual ICollection<GreetingRecipient> Recipients { get; set; }
    }

    public class GreetingRecipient : UserOwnedEntityBase
    {
        //public int GreetingId { get; set; }
        [InverseProperty("Id")]
        public Greeting Greeting { get; set; }
        // This could be either an email, or phone, 
        // twitter handle or FB handle depending on what the send method is.
        public string TargetAddress { get; set; }

        //[EnumDataType(typeof(GreetingSendMethod))]
        public int SendMethodValue { get; set; }
        [EnumDataType(typeof(GreetingSendMethod))]
        public GreetingSendMethod SendMethod
        {
            get
            {
                return (GreetingSendMethod)SendMethodValue;
            }

            set
            {
                SendMethodValue = (int)value;
            }
        }

        public virtual ICollection<GreetingSchedule> Schedules { get; set; }
    }

    public class GreetingSchedule : UserOwnedEntityBase
    {
        public string Label { get; set; }
        //public int GreetingId { get; set; }
        [InverseProperty("Id")]
        public Greeting Greeting { get; set; }
        //public int GreetingTargetId { get; set; }
        [InverseProperty("Id")]
        public GreetingRecipient Recipient { get; set; }
        public virtual ICollection<GreetingOccurence> Occurences { get; set; }
    }

    public class GreetingOccurence : UserOwnedEntityBase
    {
        //public int GreetingId { get; set; }
        [InverseProperty("Id")]
        public Greeting Greeting { get; set; }
        //public int GreetingTargetId { get; set; }
        [InverseProperty("Id")]
        public GreetingRecipient Recipient { get; set; }
        //public int GreetingScheduleId { get; set; }
        [InverseProperty("Id")]
        public GreetingSchedule Schedule { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int RepeatCount { get; set; }
    }


    public enum GreetingSendMethod
    {
        None = 0,
        Email = 1,
        SMS = 2,
        Call = 3,
        Tweet = 4,
        FBPrivateMessage = 5,
        FBWall = 6,
    }
}