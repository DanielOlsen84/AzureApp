using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureApp.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            DataAccess dataAccess = new DataAccess();
            List<ChatMessageModel> messages = dataAccess.GetChatMessages();
            string s = "";
            foreach (ChatMessageModel m in messages)
            {
                s += $"{m.UserName}: {m.Message} \n";
            }
            return View("Index", s);
        }

        public IActionResult SendChatMessage(string chatmessage, string username)
        {
            if (chatmessage == null)
                chatmessage = "Mumble...";
            chatmessage = chatmessage.Trim();
            if (chatmessage == "")
                chatmessage = "Mumble...";

            if (username == null)
                username = "Anonymous";
            username = username.Trim();
            if (username == "")
                username = "Anonymous";

            DataAccess dataAccess = new DataAccess();
            dataAccess.AddChatMessage(chatmessage, username);

            List<ChatMessageModel> messages = dataAccess.GetChatMessages();
            string s = "";
            foreach (ChatMessageModel m in messages)
            {
                s += $"{m.UserName}: {m.Message} \n";
            }
            return View("Index", s);
            //return Ok(s);
        }
    }
}
