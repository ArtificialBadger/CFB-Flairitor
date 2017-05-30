using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Models
{
    public struct Flair
    {
		public Flair(string text, string flairText)
		{
			this.Text = text;
			this.FlairText = flairText;
			this.HasFlair = !String.IsNullOrWhiteSpace(flairText);
		}
		
		public bool HasFlair
		{
			get;
		}

		public string Text
		{
			get;
		}

		public string FlairText
		{
			get;
		}

	}
}
