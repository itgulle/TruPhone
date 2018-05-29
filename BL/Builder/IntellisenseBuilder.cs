using BL.Builder;
using BL.Model;
using System.Collections.Generic;

namespace BL
{
	public class IntellisenseBuilder : BasBuilder , IIntellisenseBuilder
	{
		private readonly IEnumerable<string> StationList;
		public IntellisenseBuilder(IEnumerable<string> stationList)
		{
			StationList = stationList;
		}
		public IntelesenceModel Build(string value)
		{
			var matches = Matches(value, StationList);
			var nextCharacters = NextCharacterList(matches, value);
			return new IntelesenceModel
			{
				Stations = matches,
				NextCharacters = nextCharacters
			};			
		}
	}
}
