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
    public class HomeController : Controller
    {
		private IFlairitor flairitor;
		private IFlairFormatter formatter;

		public HomeController(IFlairitor flairitor, IFlairFormatter formatter)
		{
			this.flairitor = flairitor;
			this.formatter = formatter;
		}
		
        public ActionResult Index()
        {
			var flairitorText = new FlairitorText();

			flairitorText.Text = "Enter Text Here";

			flairitorText.FlairedText = this.formatter.FormatFlairedString(this.flairitor.GenerateFlairText(flairitorText.Text), new FlairFormatOptions(true));

			return View(flairitorText);
        }

		//[Route("Update/{text}")]
		//public ActionResult Update(string text)
		//{
		//	var flairitorText = new FlairitorText();

		//	flairitorText.Text = text;

		//	flairitorText.FlairedText = this.formatter.FormatFlairedString(this.flairitor.GenerateFlairText(flairitorText.Text), new FlairFormatOptions(true));

		//	return View("FlairLayout", flairitorText);
		//}

		[HttpPost]
		public ActionResult Update(FlairitorText model)
		{
			model.FlairedText = this.formatter.FormatFlairedString(this.flairitor.GenerateFlairText(model.Text), new FlairFormatOptions(true));

			return View("Index", model);
		}
	}
}