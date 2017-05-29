using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Abstractions
{
    public interface IService
    {
		Task<IEnumerable<string>> GetValues();
    }
}
