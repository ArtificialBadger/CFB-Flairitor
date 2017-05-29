using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Abstractions
{
	public sealed class ConcreteService : IService
	{
		public async Task<IEnumerable<string>> GetValues()
		{
			await Task.Yield();
			return new List<string>() { "Wisconsin", "Minnesota", "Alabama", "Clemson", "Ohio State" };
		}
	}
}
