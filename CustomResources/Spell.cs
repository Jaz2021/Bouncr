using Godot;
using System;

[GlobalClass]
public partial class Spell : Resource
{
    // Basic Spell Information
    [Export] public string SpellName = "";
    [Export] public int Level = 0; // 0 for cantrips, 1-9 for leveled spells
    // [Export] public string School = ""; // e.g., Evocation, Conjuration

    // // Casting Details
    // [Export] public string CastingTime = ""; // e.g., "1 Action", "1 Bonus Action"
    // [Export] public string Range = ""; // e.g., "60 feet", "Self", "Touch"

    // // Components: typically verbal (V), somatic (S), and material (M)
    // [Export] public bool ComponentVerbal = false;
    // [Export] public bool ComponentSomatic = false;
    // [Export] public bool ComponentMaterial = false;
    // [Export] public string MaterialComponents = ""; // detail any required materials

    // // Duration and special casting conditions
    // [Export] public string Duration = ""; // e.g., "Instantaneous", "1 Minute"
    // [Export] public bool IsConcentration = false; // true if the spell requires concentration
    // [Export] public bool IsRitual = false; // true if the spell can be cast as a ritual

    // // Descriptive Text
    // [Export] public string Description = ""; // main spell description
    // [Export] public string AtHigherLevels = ""; // additional effects when cast with higher-level slots

    // // Optional: Combat-related properties
    // [Export] public string DamageType = ""; // e.g., "Fire", "Cold", or leave empty if not applicable
    // [Export] public string SavingThrowType = ""; // e.g., "Dexterity", "Wisdom" if the spell requires a save

    // // Optional: Classes that can learn/cast the spell (for informational purposes)
    // [Export] public string SpellClasses = ""; // e.g., "Wizard, Sorcerer"
}
