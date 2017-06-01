using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CfbFlairitorWeb.Models;
using CfbFlairitorWeb.Services.Abstractions;

namespace CfbFlairitorWeb.Controllers
{
    public class HonestlyBaconController : Controller
    {
		private IFlairitor flairitor;
		private IFlairFormatter formatter;

		public HonestlyBaconController(IFlairitor flairitor, IFlairFormatter formatter)
		{
			this.flairitor = flairitor;
			this.formatter = formatter;
		}
		

		[Route("")]
        public ActionResult Index()
        {
			var flairitorText = new FlairitorText();

			flairitorText.Text = "Fake Time";

			flairitorText.FlairedText = this.formatter.FormatFlairedString(this.flairitor.GenerateFlairText(flairitorText.Text), new FlairFormatOptions(true));

			return View("FlairLayout", flairitorText);
        }

        // GET: HonestlyBacon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HonestlyBacon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HonestlyBacon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HonestlyBacon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HonestlyBacon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HonestlyBacon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HonestlyBacon/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}