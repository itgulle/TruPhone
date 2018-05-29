using System.Collections.Generic;

namespace BL.Builder
{
	public abstract class BasBuilder
	{
		public List<string> NextCharacterList(List<string> stations, string userInput)
		{
			var result = new List<string>();
			foreach (var station in stations)
			{
				var nextCharacter = GetNextCharacter(station, userInput);
				if (nextCharacter != null && nextCharacter.Trim() !="")
					result.Add(nextCharacter);
			}
			return result;
		}
		public List<string> Matches(string input, IEnumerable<string> stationList)
		{
			var result = new List<string>();
			foreach (var value in stationList)
			{
				if (value.Contains(input))
					result.Add(value);
			}
			return result;
		}
		private string GetNextCharacter(string station, string userInput)
		{
			if (station.ToUpper().Equals(userInput.ToUpper()))
				return null;
			return station.Substring(userInput.Length, 1);
		}
	}
}

