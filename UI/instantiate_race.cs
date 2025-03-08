using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class instantiate_race : VBoxContainer
{
    public override void _Ready()
    {
        // List<string> classKeys = GetClassKeys();
        if(Global.instance == null){
            Global.instance = new();
            Global.instance.classes = DNDclasses.GenerateClasses();
            Global.instance.races = Races.generateRaceList();
            Global.instance.spells = Spell.GenerateSpells();
        }
        List<Races> classKeys =  Global.instance.races ;
;
        
        
        foreach (Races key in classKeys)
        {
            GD.Print(key.name);  // Print each class name
            CheckBox checkbox = new CheckBox
            {
                Name = key.name,  // Unique name
                Text = key.name  // Display text
            };

            // Connect the "pressed" signal
            checkbox.Toggled += (pressed) => OnCheckboxToggled(checkbox, pressed);

            // Add to the VBoxContainer
            AddChild(checkbox);
        }
    }

    private void OnCheckboxToggled(CheckBox selectedCheckbox, bool pressed)
    {
        if (pressed)
        {
            foreach (Node child in GetChildren())
            {
                if (child is CheckBox checkbox && checkbox != selectedCheckbox)
                {
                    checkbox.ButtonPressed = false; // Uncheck others
                }
            }
        }
    }

    private List<string> GetClassKeys()
    {
        string filePath = "user://data/class/index.json";

        if (!Godot.FileAccess.FileExists(filePath))  // Explicitly use Godot.FileAccess
        {
            GD.PrintErr("Failed to open file: " + filePath);
            return new List<string>();
        }

        using Godot.FileAccess file = Godot.FileAccess.Open(filePath, Godot.FileAccess.ModeFlags.Read); // Explicitly use Godot.FileAccess
        string jsonText = file.GetAsText();

        try
        {
            Dictionary<string, string> classDict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);
            return new List<string>(classDict.Keys);
        }
        catch (Exception e)
        {
            GD.PrintErr("JSON parsing failed: " + e.Message);
            return new List<string>();
        }
    }
}



