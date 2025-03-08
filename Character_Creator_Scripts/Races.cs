using System;
using System.Collections.Generic;
using Godot;
using System.Text.Json;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;

public partial class Races : Node
{
	public string name;
	public string size;
	public int walk;
	public int fly;
	public int raceStr;
	public int raceDex;
	public int raceCon;
	public int raceInt;
	public int raceWis;
	public int raceCha;
	public List<String> languagesList;
	public List<string> resistList;
	public List<string> immuneList;
	public Races(string name, string size, int walk, int fly, int raceStr, int raceDex, int raceCon, int raceInt, int raceWis, int raceCha, List<String> languagesList, List<string> resistList, List<string> immuneList)
	{
		this.name = name;
		this.size = size;
		this.walk = walk;
		this.fly = fly;
		this.raceStr = raceStr;
		this.raceDex = raceDex;
		this.raceCon = raceCon;
		this.raceInt = raceInt;
		this.raceWis = raceWis;
		this.raceCha = raceCha;
		this.languagesList = languagesList;
		this.resistList = resistList;
		this.immuneList = immuneList;
	}
	public static List<Races> generateRaceList()
	{
		List<Races> raceList = new();
		var race = JsonUtils.ParseJsonFile("user://data/races.json");
		var raceData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(race["race"].ToString());

		foreach (var raceEntry in raceData)
		{
			var name = raceEntry["name"].ToString();
			var walk = 0;
			var fly = 0;

			var size = "M";
			try
			{
				size = JsonSerializer.Deserialize<List<string>>(raceEntry["size"].ToString())[0];
			}
			catch { }
			if (raceEntry.ContainsKey("speed"))
			{
				if (raceEntry["speed"].ToString().StartsWith('{'))
				{
					var speedDict = JsonSerializer.Deserialize<Dictionary<string, object>>(raceEntry["speed"].ToString());
					if (speedDict.ContainsKey("walk"))
					{
						walk = speedDict["walk"].ToString().ToInt();
					}
					if (speedDict.ContainsKey("fly"))
					{
						if (speedDict["fly"].ToString().ToUpper() == "TRUE")
						{
							fly = walk;
						}
						else
						{
							fly = speedDict["fly"].ToString().ToInt();
						}
					}
				}
				else
				{
					walk = raceEntry["speed"].ToString().ToInt();

				}
			}



			var raceStr = 0;
			var raceDex = 0;
			var raceCon = 0;
			var raceInt = 0;
			var raceWis = 0;
			var raceCha = 0;

			if (raceEntry.ContainsKey("ability"))
			{
				var abilDict = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(raceEntry["ability"].ToString())[0];
				if (abilDict.ContainsKey("str"))
				{
					try
					{
						raceStr = abilDict["str"].ToString().ToInt();
					}
					catch { }
				}

				if (abilDict.ContainsKey("dex"))
				{
					try
					{
						raceDex = abilDict["dex"].ToString().ToInt();
					}
					catch { }

				}

				if (abilDict.ContainsKey("con"))
				{
					try
					{
						raceCon = abilDict["con"].ToString().ToInt();
					}
					catch { }
				}

				if (abilDict.ContainsKey("int"))
				{
					try
					{
						raceInt = abilDict["int"].ToString().ToInt();
					}
					catch { }
				}

				if (abilDict.ContainsKey("wis"))
				{
					try
					{
						raceWis = abilDict["wis"].ToString().ToInt();
					}
					catch { }
				}

				if (abilDict.ContainsKey("cha"))
				{
					try
					{
						raceCha = abilDict["cha"].ToString().ToInt();
					}
					catch { }
				}
			}

			var languagesList = new List<string>();

			if (raceEntry.ContainsKey("languageProficiencies"))
			{
				var langDict = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(raceEntry["languageProficiencies"].ToString())[0];
				foreach (var line in langDict)
				{
					languagesList.Add(line.Key);
				}
			}
			var resistList = new List<string>();

			if (raceEntry.ContainsKey("resist"))
			{
				try
				{
					var resistDict = JsonSerializer.Deserialize<List<string>>(raceEntry["resist"].ToString())[0];
					foreach (var line in resistDict)
					{
						resistList.Add(line.ToString());
					}
				}
				catch { }

			}

			var immuneList = new List<string>();

			if (raceEntry.ContainsKey("conditionImmune"))
			{
				var immuneDict = JsonSerializer.Deserialize<List<string>>(raceEntry["conditionImmune"].ToString())[0];
				foreach (var line in immuneDict)
				{
					immuneList.Add(line.ToString());
				}
			}

			raceList.Add(new(name, size, walk, fly, raceStr, raceDex, raceCon, raceInt, raceWis, raceCha, languagesList, resistList, immuneList));
		}


		return raceList;

	}
}
