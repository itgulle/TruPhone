using BL;
using BL.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace TruphoneTest
{
	[TestFixture]
	public class IntellisenseBuilderTest
	{
		IIntellisenseBuilder _iIntelisenseBuilder;

		IntelesenceModel ExpectedResult_Criteria = null;
		IEnumerable<string> ExpectedStationListForCriteria = null;
		IEnumerable<string> ExpectedNextCharacterListForCriteria = null;

		/// <summary>
		/// Given a list of stations ‘DARTFORD’, ‘DARTMOUTH’, ‘TOWER HILL’, ‘DERBY’
		/// ** When input ‘DART’
		/// ** Then should return:
		/// ** The characters of ‘F’, ‘M’
		/// ** The stations ‘DARTFORD’, ‘DARTMOUTH’.
		/// </summary>
		[Test]
		public void Acceptance_Criteria_1()
		{
			ExpectedStationListForCriteria = new List<string>
			{
				"DARTFORD",
				"DARTMOUTH"
			};
			ExpectedNextCharacterListForCriteria = new List<string>
			{
				"F",
				"M"
			};
			ExpectedResult_Criteria = new IntelesenceModel
			{
				Stations = ExpectedStationListForCriteria,
				NextCharacters = ExpectedNextCharacterListForCriteria
			};

			_iIntelisenseBuilder = new IntellisenseBuilder(ExpectedStationListForCriteria);
			var userInput = "DART";
			var result = _iIntelisenseBuilder.Build(userInput);
			Assert.AreEqual(ExpectedResult_Criteria.NextCharacters, result.NextCharacters);
			Assert.AreEqual(ExpectedResult_Criteria.Stations, result.Stations);
		}
		///Given a list of stations ‘LIVERPOOL’, ‘LIVERPOOL LIME STREET’, ‘PADDINGTON’
		///** When input ‘LIVERPOOL’
		///** Then should return:
		///** The characters of ‘ ‘
		///** The stations ‘LIVERPOOL’, ‘LIVERPOOL LIME STREET’
		[Test]
		public void Acceptance_Criteria_2()
		{
			ExpectedStationListForCriteria = new List<string>
			{
				"LIVERPOOL",
				"LIVERPOOL LIME STREET"
			};
			ExpectedNextCharacterListForCriteria = new List<string>();
			ExpectedResult_Criteria = new IntelesenceModel
			{
				Stations = ExpectedStationListForCriteria,
				NextCharacters = ExpectedNextCharacterListForCriteria
			};

			var userInput = "LIVERPOOL";
			_iIntelisenseBuilder = new IntellisenseBuilder(ExpectedStationListForCriteria);
			var result = _iIntelisenseBuilder.Build(userInput);
			Assert.AreEqual(ExpectedResult_Criteria.NextCharacters, result.NextCharacters);
			Assert.AreEqual(ExpectedResult_Criteria.Stations, result.Stations);
		}
		///Given a list of stations ‘EUSTON’, ‘LONDON BRIDGE’, ‘VICTORIA’
		///** When input ‘KINGS CROSS’
		///** Then the application will return:
		///** no next characters#
		///** no stations

		[Test]
		public void Acceptance_Criteria_3()
		{
			ExpectedStationListForCriteria = new List<string>
			{
				"EUSTON",
				"LONDON BRIDGE",
				"VICTORIA"
			};
			ExpectedNextCharacterListForCriteria = new List<string>();
			ExpectedResult_Criteria = new IntelesenceModel
			{
				Stations = new List<string>(),
				NextCharacters = ExpectedNextCharacterListForCriteria
			};

			var userInput = "KINGS CROSS";
			_iIntelisenseBuilder = new IntellisenseBuilder(ExpectedStationListForCriteria);
			var result = _iIntelisenseBuilder.Build(userInput);
			Assert.AreEqual(ExpectedResult_Criteria.NextCharacters, result.NextCharacters);
			Assert.AreEqual(ExpectedResult_Criteria.Stations, result.Stations);
		}
	}
}
