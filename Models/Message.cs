using System;
using System.Collections.Generic;

namespace TheWall.Models

{
    public class Message : BaseEntity
    {
        public int MessageId {get; set;}
        public string MessageText {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public int UserId {get; set;}

        public User User { get; set;}
        public List<Comment> Comments {get; set;}
        public Message()
        {
            Comments = new List<Comment>();
        }
    }
}



