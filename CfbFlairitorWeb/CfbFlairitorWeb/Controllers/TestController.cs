using CfbFlairitorWeb.Extentions;
using CfbFlairitorWeb.Models;
using CfbFlairitorWeb.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Controllers
{
	[Controller]
	public class TestController
	{
		private IFlairitor flairitor;
		private IFlairFormatter formatter;

		public TestController(IFlairitor flairitor, IFlairFormatter formatter)
		{
			this.flairitor = flairitor;
			this.formatter = formatter;
		}

		[Route("flair/{text}")]
		[HttpGet]
		public Task<string> Test(string text)
		{
			return Task.FromResult(this.formatter.FormatFlairedString(this.flairitor.GenerateFlairText(text), new FlairFormatOptions(true)));
		}

		
	}
}
