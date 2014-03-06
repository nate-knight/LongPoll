using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LongPoll.Controllers
{
    public class SetTimeoutController : Controller
    {
        //
        // GET: /SetTimeout/

        static List<string> _chats = new List<string>();

        public ActionResult Index()
        {
            return View();
        }


        public void PostMessage(string message)
        {
            _chats.Add(message);
        }

        public string GetChats()
        {

            return (_chats.Count > 0) ? string.Join("<br/>", _chats.ToArray()) : ""; 

        }

       

    }
}
