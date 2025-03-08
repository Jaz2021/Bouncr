using Godot;
using System;

[GlobalClass]
public partial class Class : Resource
{
    // Basic Information
    [Export] public string ClassName = "";
    [Export] public string Description = "";

    // Hit Dice (for example, "d10")
    [Export] public string HitDice = "d10";
    
    // Primary Ability for the class (e.g., "Strength" for Fighters)
    [Export] public string PrimaryAbility = "";

    // Proficiencies for saving throws, weapons, armor, and tools
    [Export] public Godot.Collections.Array<string> SavingThrowProficiencies = new Godot.Collections.Array<string>();
    [Export] public Godot.Collections.Array<string> WeaponProficiencies = new Godot.Collections.Array<string>();
    [Export] public Godot.Collections.Array<string> ArmorProficiencies = new Godot.Collections.Array<string>();
    [Export] public Godot.Collections.Array<string> ToolProficiencies = new Godot.Collections.Array<string>();

    // Features: List of class features or special abilities
    [Export] public Godot.Collections.Array<string> Features = new Godot.Collections.Array<string>();

    // Spellcasting properties (if applicable)
    [Export] public bool IsSpellcaster = false;
    [Export] public string SpellcastingAbility = "";
    
    // Spell slot progression broken out by level.
    // This can be expanded to include higher-level slots as needed.
    [Export] public int SpellSlotsLevel1 = 0;
    [Export] public int SpellSlotsLevel2 = 0;
    [Export] public int SpellSlotsLevel3 = 0;
    [Export] public int SpellSlotsLevel4 = 0;
    [Export] public int SpellSlotsLevel5 = 0;
    [Export] public int SpellSlotsLevel6 = 0;
    [Export] public int SpellSlotsLevel7 = 0;
    [Export] public int SpellSlotsLevel8 = 0;
    [Export] public int SpellSlotsLevel9 = 0;

    // You can add additional properties as needed, for example:
    // - A progression table for class features per level.
    // - Special resource fields for multiclassing options.
    // - Methods to apply the class’s abilities to a character, etc.
}
