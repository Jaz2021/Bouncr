using Godot;
using System.Collections.Generic;

public partial class global_data : Node
{
    public static global_data instance;
    internal string classes;

    // Store user selections
    public string SelectedClass { get; set; } = "";
    public string SelectedRace { get; set; } = "";
    public string SelectedSpell { get; set; } = "";

    public override void _Ready()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
