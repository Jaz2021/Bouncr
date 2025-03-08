using Godot;
using System;

public partial class ClassJsonInfo : Node
{
     public override void _Ready()
    {
        GD.Print("Start");
        // Parse the JSON file into a dictionary
        var classDict = JsonUtils.ParseJsonFile("user://data/class/index.json");
        
        // Extract keys into an array
        string[] classKeys = new string[classDict.Count];
        classDict.Keys.CopyTo(classKeys, 0);

        GD.Print(classKeys);

        // Debug: Print keys to console
        foreach (string key in classKeys)
        {
            GD.Print(key);
        }
    }
}
