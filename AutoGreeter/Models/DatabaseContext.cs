using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoGreeter.Models
{
    public interface IGreeterContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<UserSession> Sessions { get; set; }
        IDbSet<Greeting> Greetings { get; set; }
        IDbSet<GreetingRecipient> GreetingRecipients { get; set; }
        IDbSet<GreetingSchedule> GreetingSchedules { get; set; }
        IDbSet<GreetingOccurence> GreetingOccurences { get; set; }
        int SaveChanges();
        void SetModified<T>(T entity) where T : class;
        void SetModified(object entity);
    }

    public class TestGreeterContext : IGreeterContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserSession> Sessions { get; set; }
        public IDbSet<Greeting> Greetings { get; set; }
        public IDbSet<GreetingRecipient> GreetingRecipients { get; set; }
        public IDbSet<GreetingSchedule> GreetingSchedules { get; set; }
        public IDbSet<GreetingOccurence> GreetingOccurences { get; set; }

        void IGreeterContext.SetModified<T>(T entity)
        {
        }

        void IGreeterContext.SetModified(object entity)
        {
        }


        public int SaveChanges()
        {
            return 1;
        }
    }

    public class DefaultGreeterContext : DbContext, IGreeterContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserSession> Sessions { get; set; }
        public IDbSet<Greeting> Greetings { get; set; }
        public IDbSet<GreetingRecipient> GreetingRecipients { get; set; }
        public IDbSet<GreetingSchedule> GreetingSchedules { get; set; }
        public IDbSet<GreetingOccurence> GreetingOccurences { get; set; }

        void IGreeterContext.SetModified<T>(T entity)
        {
            Entry<T>(entity).State = System.Data.EntityState.Modified;
        }

        void IGreeterContext.SetModified(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }
    }
}