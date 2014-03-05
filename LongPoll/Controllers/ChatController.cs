using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace LongPoll.Controllers
{
    public class ChatController : Controller
    {
        static TaskCompletionSource<string> _nextMessage
           = new TaskCompletionSource<string>();

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


        public void PostMessage(string message)
        {
            _nextMessage.SetResult(message);
            _nextMessage = new TaskCompletionSource<string>();

        }

    }
}
