using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Models
{
    public class FlairFormatOptions
    {
		public FlairFormatOptions(bool MakeTitle)
		{
			this.MakeTitle = true;
		}

		public bool MakeTitle
		{
			get;
			set;
		}
    }
}
