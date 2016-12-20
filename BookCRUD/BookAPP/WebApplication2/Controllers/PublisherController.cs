﻿using BEL_BookApp;
using BLL_BookApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class PublisherController : Controller
    {
        Publisher_BLL Publisher_BLL = new Publisher_BLL();
        //
        // GET: /Publisher/
        public ActionResult Index()
        {
            return View(Publisher_BLL.GetPublisherRecords());
        }

        public ActionResult Create(Publisher_BEL Publisher)
        {
            return View(Publisher);
        }

        [HttpPost]
        public ActionResult Save(Publisher_BEL Publisher)
        {
            if (ModelState.IsValid)
            {
                if (Publisher.PublisherId > 0)
                {
                    Publisher_BLL.UpdatePublisherRecord(Publisher);
                }
                else
                {
                    Publisher_BLL.SavePublisher(Publisher);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(Publisher);
            }
        }

        public ActionResult Edit(int id)
        {
            var Publisher = Publisher_BLL.GetPublisherRecord(id);
            return View(Publisher);
        }

        public ActionResult Delete(int id)
        {
            return View(Publisher_BLL.GetPublisherRecord(id));
        }

        [HttpPost]
        public ActionResult Remove(Publisher_BEL Publisher)
        {
            int result = Publisher_BLL.DeletePublisherRecord(Publisher.PublisherId);

            return View("Index", Publisher_BLL.GetPublisherRecords());
        }
    }
}