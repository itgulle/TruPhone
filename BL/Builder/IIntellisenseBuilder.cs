using BL.Model;

namespace BL
{
	public interface IIntellisenseBuilder
	{
		IntelesenceModel Build(string value);
	}
}
