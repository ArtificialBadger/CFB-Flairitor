using CfbFlairitorWeb.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CfbFlairitorWeb.Models;
using System.Text;

namespace CfbFlairitorWeb.Services.Concretes
{
	public class MarkdownFlairFormatter : IFlairFormatter
	{
		public string FormatFlairedString(FlairedText flairedtext, FlairFormatOptions options)
		{
			var builder = new StringBuilder();

			if (options.MakeTitle)
			{
				builder.Append("#");
			}

			foreach (var flair in flairedtext.Flairs)
			{
				if (flair.HasFlair)
				{
					builder.Append($"[{flair.Text}]{flair.FlairText}");	
				}
				else
				{
					builder.Append($"{flair.Text}");
				}
			}

			return builder.ToString();
		}
	}
}
