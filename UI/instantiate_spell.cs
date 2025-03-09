using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class instantiate_spell : VBoxContainer
{
    public static instantiate_spell instance;
    public override void _Ready()
    {
        // List<string> classKeys = GetClassKeys();
        if (Global.instance == null)
        {
            Global.instance = new();
            // Global.instance.classes = DNDclasses.GenerateClasses();
            // Global.instance.races = Races.generateRaceList();
            Global.instance.spells = Spell.GenerateSpells();
        }
        if (instance == null){
            instance = this; 
        } else {
            QueueFree();
        }
        List<Spell> classKeys = Global.instance.spells;

        var user_class = global_data.instance.classes;
        updateSubClasses();


    }
    public void updateSubClasses()
    {
        GD.Print("Updating spells");
        foreach(var child in GetChildren()){
            child.QueueFree();
        }
        foreach (Spell key in Global.instance.spells)
        {
            GD.Print(key.availableClasses.Count);
            // GD.Print(key.availableClasses);
            if(key.availableClasses == null){
                continue;
            }
            if(key.availableClasses.Contains(global_data.instance.SelectedClass)){
                if(key.level == 0){
                    continue;
                }
                // GD.Print(key.name);  // Print each class name
                    CheckBox checkbox = new CheckBox
                    {
                        Name = key.name,  // Unique name
                        Text = key.name + " (" + key.level + ")"  // Display text
                    };

                    // Connect the "pressed" signal
                    checkbox.Toggled += (pressed) => OnCheckboxToggled(checkbox, pressed);

                    // Add to the VBoxContainer
                    AddChild(checkbox);
            } else {
                // GD.Print(global_data.instance.classes);
            }


        }
    }

    private void OnCheckboxToggled(CheckBox selectedCheckbox, bool pressed)
    {
        if (pressed)
        {
            foreach(var spell in Global.instance.spells){
                if (spell.name == selectedCheckbox.Name){
                    global_data.instance.selectedSpells.Add(spell);
                }
            }
        } else {
            foreach(var spell in Global.instance.spells){
                if (spell.name == selectedCheckbox.Name){
                    global_data.instance.selectedSpells.Remove(spell);
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


