using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoGreeter.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> Sessions { get; set; }
        public DbSet<Greeting> Greetings { get; set; }
        public DbSet<GreetingRecipient> GreetingTargets { get; set; }
        public DbSet<GreetingSchedule> GreetingSchedules { get; set; }
        public DbSet<GreetingOccurence> GreetingOccurences { get; set; }
    }
}