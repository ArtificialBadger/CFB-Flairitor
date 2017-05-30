using CfbFlairitorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Services.Abstractions
{
    public interface IFlairFormatter
    {
		string FormatFlairedString(FlairedText flairedtext, FlairFormatOptions options);
	}
}
