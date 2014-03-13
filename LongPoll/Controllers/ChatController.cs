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
        //static member
        static TaskCompletionSource<string> _message
           = new TaskCompletionSource<string>();

        //
        // GET: /Chat/
        public ActionResult Index()
        {
            return View();
        }

        //PostMessage
        public void PostMessage(string message)
        {
            _message.SetResult(message);
            _message = new TaskCompletionSource<string>();
        }

        //GetNextMessage (long poll)
        public async Task<string> GetNextMessage()
        {
             return  await _message.Task;
        }

    }
}
