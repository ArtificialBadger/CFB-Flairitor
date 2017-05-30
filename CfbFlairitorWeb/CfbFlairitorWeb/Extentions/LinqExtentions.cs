using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfbFlairitorWeb.Extentions
{
    public static class LinqExtentions
    {
		private static Random random = new Random();

		public static T Random<T>(this IEnumerable<T> items)
		{
			return items.ToList()[random.Next(0, items.Count())];
		}

		public static IList<T> Randomize<T>(this IEnumerable<T> items)
		{
			var itemsList = items.ToList();
			var indecies = Enumerable.Range(0, items.Count()).ToList();

			var newListIndecies = new List<int>();

			for (var i = 0; i < items.Count(); i++)
			{
				var randomIndex = indecies.Random();
				indecies.Remove(randomIndex);
				newListIndecies.Add(randomIndex);
			}

			return newListIndecies.Select(i => itemsList[i]).ToList();
		} 
	}
}
