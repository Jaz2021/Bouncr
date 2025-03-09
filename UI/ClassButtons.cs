using Godot;
using System;

public partial class ClassButtons : Button
{
    [Export] private PackedScene CharacterSheet;
    [Export] private Node parent;
    public void CreateClass(){
        if(global_data.instance.c != null && global_data.instance.r != null && global_data.instance.subclass != null){
            Global.instance.character = new(global_data.instance.c, global_data.instance.r, global_data.instance.subclass, global_data.instance.selectedSpells);
            GD.Print(Global.instance.character);
            GD.Print("Character created!");
            var sheet = CharacterSheet.Instantiate();
            parent.GetParent().AddChild(sheet);
            parent.QueueFree();
            
        } else {
            GD.Print("Character failed");
            GD.Print(global_data.instance.r.name);
            GD.Print(global_data.instance.c.name);
            GD.Print(global_data.instance.subclass.name);
            GD.Print(global_data.instance.selectedSpells.Count);
        }
    }
}
