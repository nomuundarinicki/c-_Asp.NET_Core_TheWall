using System;
using System.Collections.Generic;

namespace TheWall.Models{
    public class User : BaseEntity
    {
        public int UserID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Message> Messages {get; set;}
        public List<Comment> Comments {get; set;}
        public User()
        {
            Messages = new List<Message>();
            Comments = new List<Comment>();
        }

    }
}