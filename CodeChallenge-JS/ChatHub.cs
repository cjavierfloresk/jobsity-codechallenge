using System;
using System.Web;
using CodeChallenge_JS.Data;
using CodeChallenge_JS.Models;
using Microsoft.AspNet.SignalR;
namespace CodeChallenge
{
    public class ChatHub : Hub
    {
        private DataContext _context = new DataContext();
        public void Send(string name, string message)
        {
            //save the message
            var m = new Message
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Text = message,
                UserName = name
            };

            _context.Entry(m).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();

            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}