using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheWall.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TheWall.Controllers
{
    public class MessagesController : Controller
    {
        private WallContext _context;

        public MessagesController(WallContext context)
        {
          _context = context;
        }

        [HttpGet]
        [Route("Messages")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
              ViewBag.AllMessages = _context.Messages
                .Include(post => post.User)
                .OrderByDescending(post => post.CreatedAt)
                .Include(post => post.Comments)
                  .ThenInclude(comment => comment.User)
                .ToList();
              int? logId = HttpContext.Session.GetInt32("UserId");
              ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
              return View();
            }
            else
            {
              return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [Route("PostMessage")]
        public IActionResult PostMessage(Message message)
        {
          if (HttpContext.Session.GetInt32("UserId") != null)
          {
            Message NewMessage = new Message{
              MessageText = message.MessageText,
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
              UserId = (int)HttpContext.Session.GetInt32("UserId")
            };
            _context.Messages.Add(NewMessage);
            _context.SaveChanges();
            ViewBag.AllMessages = _context.Messages
              .Include(post => post.User)
              .OrderByDescending(post => post.CreatedAt)
              .Include(post => post.Comments)
                .ThenInclude(thisComment => thisComment.User)
              .ToList();
            int? logId = HttpContext.Session.GetInt32("UserId");
            ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
            ModelState.Clear();
            return RedirectToAction("Index");
          }
          else
          {
            return RedirectToAction("Index", "Login");
          }
        }

        [HttpPost]
        [Route("PostComment")]
        public IActionResult PostComment(string CommentText, int MessageId)
        {
          Console.WriteLine("Message ID is: " + MessageId);
          if (HttpContext.Session.GetInt32("UserId") != null)
          {
            Comment NewComment = new Comment{
              CommentText = CommentText,
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
              MessageId = MessageId,
              UserId = (int)HttpContext.Session.GetInt32("UserId")
            };
            _context.Comments.Add(NewComment);
            _context.SaveChanges();
            ViewBag.AllMessages = _context.Messages
              .Include(post => post.User)
              .OrderByDescending(post => post.CreatedAt)
              .Include(post => post.Comments)
                .ThenInclude(thisComment => thisComment.User)
              .ToList();
            int? logId = HttpContext.Session.GetInt32("UserId");
            ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
            ModelState.Clear();
            return RedirectToAction("Index");
          }
          else
          {
            return RedirectToAction("Index", "Login");
          }
        }
    }
}