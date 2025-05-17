using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExerciseTests.TestData;

public static class PagestTestData
{
	public static IEnumerable<string[]> RegisterUserTestData
	{
		get
		{
			yield return new string[] { "Jurek", "juras@gmail.com", "pass1", "Jurek", "Mondry", "MangoMango", "Wieliczka street", "", "California", "Lost Angeles", "44-560", "1234567890" };
		}
	}
}
