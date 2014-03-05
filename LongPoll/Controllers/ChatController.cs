using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using LongPoll.Models;


namespace LongPoll.Controllers
{
    public class ChatController : Controller
    {
        static TaskCompletionSource<string> _nextMessage
           = new TaskCompletionSource<string>();

        class Chat
        {
            public string text { get; set; }
        }

        static List<Chat> _chats = new List<Chat>();

        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }

        public string GetNextMessage()
        {
            Thread.Sleep(2000);

            return "GetNextMessage: " + DateTime.Now.ToLongTimeString();
        }


        public async Task<string> GetNextMessageLongPoll()
        {
            //Thread.Sleep(2000);

            //await Task.Delay(2000);
            //return "GetNextMessageLongPoll " + DateTime.Now.ToLongTimeString() + " count " + counter;

            return await _nextMessage.Task;
        }


        //public string GetChatHistory()
        //{
        //    return Json(_chats).ToString();
        //}

        public void PostMessage(string message)
        {
            _nextMessage.SetResult(message);
            _nextMessage = new TaskCompletionSource<string>();

           // Chat newChat = new Chat();
           // newChat.text = message;

           // _chats.Add(newChat);
        }

    }
}
