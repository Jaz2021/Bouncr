using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class instantiate_subclass : VBoxContainer
{
    public static instantiate_subclass instance;
    public override void _Ready()
    {
        if(instance == null){
            instance = this;
        } else {
            QueueFree();
        }
    }
    public void updateSubclasses(){
        List<DNDclasses> classKeys =  Global.instance.classes ;
;
        foreach(var child in GetChildren()){
            child.QueueFree();
        }
        
        foreach (DNDclasses key in classKeys)
        {
            if(key.name == global_data.instance.SelectedClass){
                foreach(Subclasses subclass in key.subclasses){
                    CheckBox checkbox = new CheckBox
                    {
                        Name = subclass.name ,  // Unique name
                        Text = subclass.name   // Display text
                    };

                    // Connect the "pressed" signal
                    checkbox.Toggled += (pressed) => OnCheckboxToggled(checkbox, pressed);

                    // Add to the VBoxContainer
                    AddChild(checkbox);
                }
            }
            GD.Print(key.name);  // Print each class name
            
        }
    }
    private void OnCheckboxToggled(CheckBox selectedCheckbox, bool pressed)
    {
        GD.Print("Pressed class button");
        if (pressed)
        {
            // global_data.instance.SelectedClass = selectedCheckbox.Name;
            foreach (Node child in GetChildren())
            {
                if (child is CheckBox checkbox && checkbox != selectedCheckbox)
                {
                    checkbox.ButtonPressed = false; // Uncheck others
                }
            }
        }
        if(global_data.instance.c != null){
            foreach(var sub in global_data.instance.c.subclasses){
                if(sub.name == selectedCheckbox.Name){
                    global_data.instance.subclass = sub;
                    break;
                }
            }
        }
        // instantiate_spell.instance.updateSubClasses();
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


