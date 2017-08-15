using System;

namespace TheWall.Models
{
  public class Comment : BaseEntity
  {
    public int CommentId { get; set; }
    public string CommentText { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int MessageId { get; set; }
    public int UserId { get; set; }
    public Message Message { get; set; }
    public User User { get; set; }
  }
}