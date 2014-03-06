﻿using System;
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

        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }

        public async Task<string> GetNextMessageLongPoll()
        {
            
            var x =  await _nextMessage.Task;

            return x;
        }


        public void PostMessage(string message)
        {
            _nextMessage.SetResult(message);
            _nextMessage = new TaskCompletionSource<string>();

        }

    }
}
