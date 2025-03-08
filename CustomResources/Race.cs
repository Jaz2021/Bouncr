using Godot;
using System;
using System.Collections.Generic;

public enum SizeType
{
    Tiny,
    Small,
    Medium,
    Large,
    Huge
}

[GlobalClass]
public partial class Race : Resource
{
    // Basic information
    [Export] public string Name = "";
    [Export] public string Description = "";

    // Physical traits
    [Export] public SizeType Size = SizeType.Medium;
    [Export] public int BaseSpeed = 30; // in feet per round

    // Ability Score Bonuses: you can customize this approach.
    // Option 1: Individual fields:
    [Export] public int StrengthBonus = 0;
    [Export] public int DexterityBonus = 0;
    [Export] public int ConstitutionBonus = 0;
    [Export] public int IntelligenceBonus = 0;
    [Export] public int WisdomBonus = 0;
    [Export] public int CharismaBonus = 0;

    // Option 2: A dictionary for dynamic access (requires custom editor support if you want it to be user friendly)
    // [Export] public Dictionary<string, int> AbilityBonuses = new Dictionary<string, int>()
    // {
    //     { "Strength", 0 },
    //     { "Dexterity", 0 },
    //     { "Constitution", 0 },
    //     { "Intelligence", 0 },
    //     { "Wisdom", 0 },
    //     { "Charisma", 0 }
    // };

    // Senses and other special traits
    [Export] public bool HasDarkvision = false;
    [Export] public Godot.Collections.Array<string> RacialTraits;// = new List<string>();

    // Languages the race knows by default
    [Export] public Godot.Collections.Array<string> Languages = new Godot.Collections.Array<string> { "Common" };

    // Subraces (if any)
    // [Export] public List<SubRace> SubRaces = new List<SubRace>();
}

// [GlobalClass]
// public partial class SubRace : Resource
// {
//     [Export] public string Name = "";
//     [Export] public string Description = "";

//     // Optional: subrace-specific ability score bonuses
//     [Export] public int StrengthBonus = 0;
//     [Export] public int DexterityBonus = 0;
//     [Export] public int ConstitutionBonus = 0;
//     [Export] public int IntelligenceBonus = 0;
//     [Export] public int WisdomBonus = 0;
//     [Export] public int CharismaBonus = 0;

//     // Additional subrace features or trait overrides
//     [Export] public List<string> AdditionalTraits = new List<string>();
// }
