using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyUtubeApp.Models;

namespace MyUtubeApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult Uploadvideo()
        //{
            
        //        return View();
        //}
        [HttpGet]
        public ActionResult Uploadvideo(ChannelViewModel chl)
        {
            using (var db = new MyUtubeEntities1())
            {
                var channelList = db.Channels.Where(u => u.UserId == CurrentSession.CurrentUser.Id)
                                    .Select(x => new ChannelViewModel
                                    {
                                        Value = x.Id,
                                        Text = x.ChannelName
                                    }).ToList();
                ViewBag.ChannelList = channelList;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Uploadvideo(AddchannelViewModel chnl)
        {
            using (var db = new MyUtubeEntities1())
            {
               //var chnl = new AddchannelViewModel();
                var channel = new Channel();
                {
                    channel.ChannelName = chnl.Channelname;
                    channel.ChannelDescription = chnl.Channeldescription;
                    channel.UserId = CurrentSession.CurrentUser.Id;
                }
                db.Channels.Add(channel);
                db.SaveChanges();
            }
            return View();
        }
       
    }
}