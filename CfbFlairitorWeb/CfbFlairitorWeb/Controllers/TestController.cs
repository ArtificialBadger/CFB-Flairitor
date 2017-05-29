using CfbFlairitorWeb.Abstractions;
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
		private readonly IService service;

		public TestController(IService service)
		{
			this.service = service;
		}

		[Route("test/{text}")]
		[HttpGet]
		public async Task<string> Test(string text)
		{
			await Task.Delay(0);

			var builder = new StringBuilder();
			InitFlairList();

			builder.Append("#");
			foreach (var c in text)
			{
				builder.Append(GetFlairForCharacter(c));
			}

			builder.Append(Environment.NewLine);
			//builder.ToString().Count().Dump("Length");
			return builder.ToString();
		}

		public string GetFlairForCharacter(char c)
		{
			var invarientChar = char.ToLowerInvariant(c);
			return this.flairList.ContainsKey(invarientChar) ? this.flairList[invarientChar].First() : Convert.ToString(c); // TODO: .Random() LINQ extention
		}

		private IDictionary<char, ISet<string>> flairList;

		public void InitFlairList()
		{
			flairList = new Dictionary<char, ISet<string>>()
	{
		{
			'a', new HashSet<string>() { "[A](#f/a)", "[A](#f/alaskafairbanks-sheet7-row09-col02)", "[A](#f/allen-sheet7-row05-col01)", "[A](#f/auro-sheet6-row29-col01)", "[A](#f/asia-sheet6-row20-col01)", "[A](#f/uamn-sheet5-row20-col04)", "[A](#f/ipnsantotomas-sheet5-row16-col03)", "[A](#f/mountallison-sheet5-row08-col02)", "[A](#f/acadia-sheet5-row08-col01)", "[A](#f/amherst-sheet3-row18-col01)", "[A](#f/albright-sheet3-row13-col01)", "[A](#f/alma-sheet3-row12-col03)", "[A](#f/arizona)", "[A](#f/alcornstate)", "[A](#l/aac)", "[A](#f/stanselm-sheet2-row12-col09)" }
		}
		,
		{
			'b', new HashSet<string>() { "[B](#f/b)", "[Bluefield State](#f/bluefieldstate-sheet7-row07-col02)", "[B](#f/bradley-sheet7-row03-col01)", "[B](#f/bjut-sheet6-row24-col05)", "[B](#f/brunel-sheet5-row07-col07)", "[B](#f/bradford-sheet5-row06-col02)", "[B](#f/derby-sheet5-row03-col03)", "[B](#f/longbeachcity-sheet4-row15-col09)", "[B](#f/birminghamsouthern-sheet3-row24-col02)", "[B](#f/benedictine-sheet3-row15-col02)", "[B](#f/bentley-sheet2-row12-col03)", "[B](#f/belhaven-sheet3-row02-col01)" }
		}
		,
		{
			'c', new HashSet<string>() { "[C](#f/c)", "[C](#f/collegecharleston-sheet7-row04-col04)", "[C](#f/centenary-sheet7-row04-col03)", "[C](#f/beauceappalaches-sheet5-row14-col01)", "[C](#f/cabrillo-sheet4-row12-col01)", "[C](#f/carrollmt-sheet4-row03-col01)", "[C](#f/chapman-sheet3-row26-col02)", "[C](#f/centre-sheet3-row24-col03)", "[C](#f/chicago-sheet3-row24-col04)", "[C](#f/concordiamoorhead-sheet3-row11-col04)", "[C](#f/sunycortland-sheet3-row06-col04)", "[C](#f/cincinnati)", "[C](#f/charlotte)", "[C](#f/centralmichigan)", "[C](#f/colgate)", "[C](#f/chattanooga)", "[C](#f/chowan-sheet2-row02-col02)", "[C](#f/carthage-sheet3-row03-col02)", "[C](#f/carrollwi-sheet3-row03-col03)" }
		}
		,
		{
			'd', new HashSet<string>() { "[D](#f/d)", "[D](#f/dokkyo-sheet6-row21-col12)", "[D](#f/osakakyoiku-sheet6-row11-col07)", "[D](#f/troisrivieres-sheet5-row14-col08)", "[D](#f/durham-sheet5-row03-col04)", "[D](#f/dean-sheet3-row05-col05)", "[D](#f/denison-sheet3-row16-col02)", "[D](#f/dickinson-sheet3-row04-col01)", "[D](#f/duke)", "[D](#f/dartmouth)", "[D](#f/dayton)", "[D](#l/dallas)", "[D](#f/ohiodominican-sheet2-row05-col11)" }
		}
		,
		{
			'e', new HashSet<string>() { "[E](#f/e)", "[E](#f/shawinigan-sheet5-row15-col09)", "[E](#f/easternconnecticutstate-sheet4-row30-col04)", "[E](#f/wisconsineauclaire-sheet3-row29-col01)", "[E](#f/easternmichigan)", "[E](#f/elon)", "[E](#f/easttennesseestate)", "[E](#f/emporiastate-sheet2-row11-col03)" }
		}
		,
		{
			'f', new HashSet<string>() { "[F](#f/f)", "[F](#f/csufullerton-sheet7-row02-col03)" }
		}
		,
		{
			'g', new HashSet<string>() { "[G](#f/g)", "[G](#f/gakushuin-sheet6-row12-col03)", "[G](#f/kyoto-sheet6-row02-col01)", "[G](#f/jonquiere-sheet5-row15-col05)", /*"[G](#f/gattacaflorida-sheet4-row29-col01)",*/ /*"[G](#f/gardencitycc-sheet4-row20-col05)",*/ "[G](#f/saddleback-sheet4-row15-col16)", "[G](#f/grovecity-sheet3-row23-col05)", "[G](#f/guilford-sheet3-row22-col04)", "[G](#f/gettysburg-sheet3-row04-col03)", "[G](#f/georgetown)", "[G](#f/gramblingstate)", "[G](#f/glenvillestate-sheet2-row10-col04)" }
		}
		,
		{
			'h', new HashSet<string>() { "[H](#f/h)", "[H](#f/huntington-sheet7-row11-col05)", "[H](#f/edogawa-sheet6-row21-col11)", "[H](#f/hokkaido-sheet6-row06-col03)", "[H](#f/holland-sheet5-row12-col02)", "[H](#f/hartford-sheet4-row31-col02)", "[H](#f/hastings-sheet4-row04-col06)", "[H](#f/huntingdon-sheet3-row28-col04)", "[H](#f/hobart-sheet3-row09-col01)", "[H](#f/harvard)", "[H](#f/hendersonstate-sheet2-row04-col05)", "[H](#f/husson-sheet3-row05-col07)" }
		}
		,
		{
			'i', new HashSet<string>() { "[I](#f/i)", "[I](#f/kogakuin-sheet6-row21-col04)", "[I](#f/illinois)", "[I](#f/indiana2-sheet1-row04-col15)", "[I](#f/indianapolis-sheet2-row06-col01)" }
		}
		,
		{
			'j', new HashSet<string>() { "[J](#f/j)" }
		}
		,
		{
			'k', new HashSet<string>() { "[K](#f/k)", "[K](#f/kanagawatech-sheet6-row21-col14)", "[K](#f/kurume-sheet6-row08-col01)", "[K](#f/knox-sheet3-row14-col05)", "[K](#f/kalamazoo-sheet3-row12-col05)" }
		}
		,
		{
			'l', new HashSet<string>() { "[L](#f/l)", "[L](#f/loyolachicago-sheet7-row04-col09)", "[L](#f/wisconsinlacrosse-sheet3-row29-col02)", "[L](#f/lafayette)", "[L](#f/lehigh)", "[L](#f/lycoming-sheet3-row13-col07)" }
		}
		,
		{
			'm', new HashSet<string>() { "[M](#f/m)", "[M](#f/midplainscc-sheet7-row13-col24)", "[M](#f/collegemarin-sheet7-row13-col06)", "[M](#f/menlo-sheet7-row05-col09)", "[M](#f/manhattan-sheet7-row04-col11)", "[M](#f/meisei-sheet6-row21-col07)", "[M](#f/mie-sheet6-row17-col01)", "[M](#f/murorantech-sheet6-row14-col03)", "[M](#f/mcgill-sheet5-row11-col04)", "[M](#f/mcmaster-sheet5-row10-col03)", "[M](#f/saintmarys-sheet5-row08-col04)", "[M](#f/mansfield-sheet4-row32-col04)", "[M](#f/mayvillestate-sheet4-row09-col04)", "[M](#f/millsaps-sheet3-row24-col06)", "[M](#f/muhlenberg-sheet3-row04-col08)", "[M](#f/michigan)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/minnesota)", "[M](#f/michigan2-sheet1-row04-col16)", "[M](#f/murraystate)", "[M](#f/mercyhurst-sheet2-row13-col11)", "[M](#f/millikin-sheet3-row03-col06)" }
		}
		,
		{
			'n', new HashSet<string>() { "[N](#f/n)", "[N](#f/northeastern-sheet7-row02-col11)", "[N](#f/northampton-sheet5-row06-col17)", "[N](#f/northumbria-sheet5-row04-col08)", "[N](#f/northwestmississippicc-sheet4-row19-col12)", "[N](#f/northlandctc-sheet4-row18-col09)", "[N](#f/nebraska)", "[N](#f/northwestern)", "[N](#f/navy)", "[N](#f/nicholls)", "[N](#f/newberry-sheet2-row17-col07)" }
		}
		,
		{
			'o', new HashSet<string>() { "[O](#f/o)", "[O](#f/sise-sheet6-row25-col08)", "[O](#f/otemongakuin-sheet6-row11-col12)", "[O](#f/amu-sheet5-row30-col01)", "	[O](#f/oxford-sheet5-row05-col07)", "[O](#f/ohiostate)", "[O](#f/ohiostate3-sheet1-row04-col19)", "[O](#f/oregon)" }
		}
		,
		{
			'p', new HashSet<string>() { "[P](#f/p)", "[P](#f/portland-sheet7-row04-col12)", "[P](#f/pepperdine-sheet7-row03-col14)", "[P](#f/kyushu-sheet6-row08-col02)", "[P](#f/uqtr-sheet5-row11-col07)", "[P](#f/edinburgh-sheet5-row06-col07)", "[P](#f/purdue)", "[P](#f/pennsylvania)", "[P](#f/princeton)", "[P](#l/pioneer)", "[P](#f/liupost-sheet2-row12-col04)" }
		}
		,
		{
			'q', new HashSet<string>() { "[Q](#f/q)", "[Q](#f/queens-sheet5-row10-col05)", "[Q](#f/quincy-sheet2-row06-col05)" }
		}
		,
		{
			'r', new HashSet<string>() { "[R](#f/r)", "[R](#f/melbourne-sheet5-row21-col03)", "[R](#f/regina-sheet5-row09-col04)", "[R](#f/rockford-sheet3-row15-col06)", "[R](#f/ripon-sheet3-row14-col10)", "[R](#f/rosehulman-sheet3-row07-col09)", "[R](#f/rutgers)", "[R](#f/rice)" }
		}
		,
		{
			's', new HashSet<string>() { "[S](#f/s)", "[S](#f/saleminternational-sheet7-row07-col16)", "[S](#f/swarthmore-sheet7-row06-col17)", "[S](#f/bogazici-sheet6-row33-col05)", "[S](#f/beijingsport-sheet6-row24-col03)", "[S](#f/kanda-sheet6-row21-col15)", "[S](#f/shibaura-sheet6-row20-col20)", "[S](#f/setsunan-sheet6-row18-col15)", "[S](#f/parisrenedescartes-sheet5-row30-col15)", "[S](#f/inptoulouse-sheet5-row30-col07)", "[S](#f/sherbrooke-sheet5-row11-col06)", "[S](#f/collegesequoias-sheet4-row13-col05)", "[S](#f/wisconsinstout-sheet3-row29-col07)", "[S](#f/sewanee-sheet3-row24-col08)", "[S](#f/susquehanna-sheet3-row04-col09)", "[S](#f/syracuse)", "[S](#f/stanford)", "[S](#f/shepherd-sheet2-row10-col06)", "[S](#f/stonehill-sheet2-row12-col10)" }
		}
		,
		{
			't', new HashSet<string>() { "[T](#f/t)", "[T](#f/transylvania-sheet7-row11-col19)", "[T](#f/teikyoheisei-sheet6-row21-col05)", "[T](#f/teikyo-sheet6-row04-col03)", "[T](#f/puebla-sheet5-row18-col03)", "[T](#f/uag-sheet5-row17-col06)", "[T](#f/thetford-sheet5-row15-col12)", "[T](#f/lanaudiere-sheet5-row14-col05)", "[T](#f/toronto-sheet5-row10-col06)", "[T](#f/texastech)", "[T](#f/trinitytx-sheet3-row25-col04)", "[T](#f/temple)", "[T](#f/trine-sheet3-row12-col07)", "[T](#f/tulane)", "[T](#f/troy)", "[T](#f/tarletonstate-sheet2-row09-col05)" }
		}
		,
		{
			'u', new HashSet<string>() { "[U](#f/u)", "[U](#f/portsmouth-sheet5-row05-col08)", "[U](#f/staffordshire-sheet5-row04-col11)", "[U](#f/union-sheet3-row09-col07)", "[U](#f/miami)", "[U](#f/usf)", "[U](#f/urbana-sheet2-row10-col07)"}
		}
		,
		{
			'v', new HashSet<string>() { "[V](#f/v)", "[V](#f/laurentian-sheet7-row16-col03)", "[V](#f/drummondville-sheet5-row14-col03)",  "[V](#f/vermillion-sheet4-row18-col12)", "[V](#f/virginia)", "[V](#f/villanova)", "[V](#f/valleycup-sheetl-row20-col10)", "[V](#f/virginiaunion-sheet2-row02-col11)", "[V](#f/valdostastate-sheet2-row08-col07)" }
		}
		,
		{
			'w', new HashSet<string>() { "[W](#f/w)", "[W](#f/wakayama-sheet6-row18-col08)", "[W](#f/yokkaichi-sheet6-row17-col06)", "[W](#f/waseda-sheet6-row03-col05)", "[W](#f/kindai-sheet6-row11-col11)", "[W](#f/monash-sheet5-row21-col04)", "[W](#f/webberinternational-sheet4-row10-col06)", "[W](#f/wesleyan-sheet3-row18-col09)", "[W](#f/wooster-sheet3-row16-col10)", "[W](#f/wilkes-sheet3-row13-col10)", "[W](#f/wisconsin)","[W](#f/wisconsin)","[W](#f/wisconsin)","[W](#f/wisconsin)","[W](#f/wisconsin)","[W](#f/wisconsin)","[W](#f/wisconsin)", "[W](#f/washington)", "[W](#f/waynestatemi-sheet2-row05-col15)", "[W](#f/washburn-sheet2-row11-col12)" }
		}
		,
		{
			'x', new HashSet<string>() { "[X](#f/x)", "[X](#f/xavier-sheet7-row03-col24)", "[X](#f/standrews-sheet6-row11-col09)", "[X](#f/stfrancisxavier-sheet5-row08-col03)" }
		}
		,
		{
			'y', new HashSet<string>() { "[Y](#f/y)", "[Y](#f/byu)", "[Y](#f/yale)" }
		}
		,
		{
			'z', new HashSet<string>() { "[Z](#f/z)", "[Z](#f/akron)" }
		}

	};
		}
	}
}
