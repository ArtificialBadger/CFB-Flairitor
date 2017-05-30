using CfbFlairitorWeb.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CfbFlairitorWeb.Models;
using CfbFlairitorWeb.Extentions;

namespace CfbFlairitorWeb.Services.Concretes
{
	public class SingleLetterReplacementFlairitor : IFlairitor
	{
		private IFlairResolver flairResolver;

		public SingleLetterReplacementFlairitor(IFlairResolver flairResolver)
		{
			this.flairResolver = flairResolver;
		}

		public FlairedText GenerateFlairText(string text)
		{
			var flairedLetters = new List<Flair>(); 

			var flairDictionary = this.flairResolver.ResolveFlair().GroupBy(f => f.Text).ToDictionary(g => g.Key);

			foreach (var letter in text)
			{
				var key = Char.ToUpperInvariant(letter).ToString();
				if (flairDictionary.ContainsKey(key))
				{
					var flair = flairDictionary[key].Random();
					flairedLetters.Add(flair);
				}
				else
				{
					flairedLetters.Add(new Flair(key, String.Empty));
				}
			}

			return new FlairedText() { Flairs = flairedLetters };
		}
	}
}
