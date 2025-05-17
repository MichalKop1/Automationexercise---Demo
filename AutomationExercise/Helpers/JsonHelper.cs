using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using AutomationExercise.Common;

namespace AutomationExercise.Helpers;

public static class JsonHelper
{
	private static ObjectClass _settings;
	private static Browser _browser = Browser.Null;
	public static ObjectClass GetJsonSettings
	{
		get
		{
			if (_settings == null)
			{
				string jsonPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Common//AppSettings.json");
	
				string a = File.ReadAllText(jsonPath);

				_settings = JsonSerializer.Deserialize<ObjectClass>(a);
			}
			
			return _settings;
		}
	}

	public static Browser GetBrowser
	{
		get
		{
			if (_browser == Browser.Null)
			{
				if (!Enum.TryParse(_settings.Browsers.Browser, out _browser))
				{
					_browser = Browser.Chrome;
				}
			}

			return _browser;
		}
	}
}
