using CfbFlairitorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Services.Abstractions
{
    public interface IFlairResolver
    {
		IEnumerable<Flair> ResolveFlair(); 
    }
}
