using OpenQA.Selenium.DevTools.V134.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Common;

public class ObjectClass
{
	public required string ConnectionLink { get; set; }
	public required string LoginOrRegisterLink { get; set; }
	public Browsers Browsers { get; set; }
}

public class Browsers
{
	public string Browser { get; set; }
	public List<string> CumulatedBrowsers { get; set; }
}
