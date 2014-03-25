using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LongPoll.Controllers
{
    public class ChatController : Controller
    {
        //shared member
        //links our GetNextMessage() and ChatMessage() methods asynchronously
        static TaskCompletionSource<string> _message
           = new TaskCompletionSource<string>();

       
        // GET: /Chat/
        public ActionResult Index()
        {
            return View();
        }

        //(long poll method)
        public async Task<string> GetNextMessage()
        {
            var response = await _message.Task; //Don't respond to client(s) until _message.SetResult is called in ChatMessage 
            
            return response;
        }

        //
        public void ChatMessage(string message)
        {
            _message.SetResult(message); //we've got what we are waiting for! GetNextMessage can now respond to client(s).
            _message = new TaskCompletionSource<string>();
        }

    }
}
