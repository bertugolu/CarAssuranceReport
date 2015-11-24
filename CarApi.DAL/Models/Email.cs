using System;

namespace CAR.DAL.Models
{
    public class Email
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateSubscribed { get; set; }
    }
}
