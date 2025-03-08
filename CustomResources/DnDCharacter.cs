using Godot;
using System;
using System.Collections.Generic;

// Enums for some common options
// public enum RaceType { Human, Elf, Dwarf, Halfling, Orc, Tiefling, Dragonborn, Gnome, Other }
// public enum ClassType { Fighter, Wizard, Rogue, Cleric, Barbarian, Bard, Druid, Monk, Paladin, Ranger, Sorcerer, Warlock, Other } 
public enum Alignment { LawfulGood, NeutralGood, ChaoticGood, LawfulNeutral, TrueNeutral, ChaoticNeutral, LawfulEvil, NeutralEvil, ChaoticEvil }   
public enum Dice {d2, d4, d6, d8, d10, d12, d20}   

[GlobalClass]
public partial class DnDCharacter : Resource
{
    // Basic Character Information
    [Export] public string CharacterName = "First Last";

    [Export] public int Level = 1;
    [Export] public string Class = "Fighter";//new Class();
    [Export] public string Background = "Noble";
    [Export] public string PlayerName = "John Doe";

    [Export] public string Race = "Human";//new Race();
    [Export] public Alignment Alignment = Alignment.TrueNeutral;
    [Export] public int ExperiencePoints = 0;

    // Ability Scores with group export for better organization in the inspector
    [ExportGroup("Ability Scores")]
    [Export] public int Strength = 10;
    [Export] public int Dexterity = 10;
    [Export] public int Constitution = 10;
    [Export] public int Intelligence = 10;
    [Export] public int Wisdom = 10;
    [Export] public int Charisma = 10;

    // Computed ability modifiers
    public int StrengthModifier => (Strength - 10) / 2;
    public int DexterityModifier => (Dexterity - 10) / 2;
    public int ConstitutionModifier => (Constitution - 10) / 2;
    public int IntelligenceModifier => (Intelligence - 10) / 2;
    public int WisdomModifier => (Wisdom - 10) / 2;
    public int CharismaModifier => (Charisma - 10) / 2;

    [ExportGroup("Proficiencies")]
    [Export] public int ProficiencyBonus = 2;
    [Export] public bool Inspiration = false;

    [ExportGroup("Saving Throws")]
    [Export] public bool StrengthSaveProficient = false;
    [Export] public bool DexteritySaveProficient = false;
    [Export] public bool ConstitutionSaveProficient = false;
    [Export] public bool IntelligenceSaveProficient = false;
    [Export] public bool WisdomSaveProficient = false;
    [Export] public bool CharismaSaveProficient = false;

    [ExportGroup("Skills")]
    //Dex
    [Export] public Skill Acrobatics = new Skill { Name = "Acrobatics", IsProficient = false, Bonus = 0};
    [Export] public Skill SleightOfHand = new Skill { Name = "SleightOfHand", IsProficient = false, Bonus = 0};
    [Export] public Skill Stealth = new Skill { Name = "Stealth", IsProficient = false, Bonus = 0};

    //Wis
    [Export] public Skill AnimalHandling = new Skill { Name = "AnimalHandling", IsProficient = false, Bonus = 0};
    [Export] public Skill Insight = new Skill { Name = "Insight", IsProficient = false, Bonus = 0};
    [Export] public Skill Medicine = new Skill { Name = "Medicine", IsProficient = false, Bonus = 0};
    [Export] public Skill Perception = new Skill { Name = "Perception", IsProficient = false, Bonus = 0};
    [Export] public Skill Survival = new Skill { Name = "Survival", IsProficient = false, Bonus = 0};

    //Int
    [Export] public Skill Arcana = new Skill { Name = "Arcana", IsProficient = false, Bonus = 0};
    [Export] public Skill History = new Skill { Name = "History", IsProficient = false, Bonus = 0};
    [Export] public Skill Investigation = new Skill { Name = "Investigation", IsProficient = false, Bonus = 0};
    [Export] public Skill Nature = new Skill { Name = "Nature", IsProficient = false, Bonus = 0};
    [Export] public Skill Religion = new Skill { Name = "Religion", IsProficient = false, Bonus = 0};

    //Str
    [Export] public Skill Athletics = new Skill { Name = "Athletics", IsProficient = false, Bonus = 0};

    //Cha
    [Export] public Skill Deception = new Skill { Name = "Deception", IsProficient = false, Bonus = 0};
    [Export] public Skill Intimidation = new Skill { Name = "Intimidation", IsProficient = false, Bonus = 0};
    [Export] public Skill Performance = new Skill { Name = "Performance", IsProficient = false, Bonus = 0};
    [Export] public Skill Persuasion = new Skill { Name = "Persuasion", IsProficient = false, Bonus = 0};
    
    // Combat-related stats
    [ExportGroup("Combat")]
    [Export] public int ArmorClass = 10;
    // [Export] public int  = 10;
    // Initiative is typically based on Dexterity modifier
    public int Initiative => DexterityModifier;
    [Export] public int Speed = 30;
    [Export] public int HitPointMaximum = 10;
    [Export] public int CurrentHitPoints = 10;
    [Export] public int TemporaryHitPoints = 10;

    [Export] public int HitDiceTotal = 0;
    [Export] public Dice HitDice = Dice.d6;

    [Export] public int DeathSaveSuccess = 0;
    [Export] public int DeathSaveFailier = 0;


    // Proficiencies and other modifiers


    // Saving Throws: whether the character is proficient in each saving throw

    // // Skills, Inventory, Spells, and Features can be expanded further
    // [Export] public List<Skill> Skills = new List<Skill>();
    // [Export] public List<Item> Inventory = new List<Item>();
    [Export] public Godot.Collections.Array<string> Items;// = Godot.Collections.Array<Spell>();
    [Export] public Godot.Collections.Array<string> Spells;// = Godot.Collections.Array<Spell>();
    // [Export] public List<string> Features = new List<string>();

    // /// <summary>
    // /// Calculates a skill bonus based on the underlying ability and proficiency.
    // /// This example uses common D&D 5e skill-to-ability associations.
    // /// </summary>
    public int GetSkillBonus(Skill skill)
    {
        int baseBonus = 0;
        // Associate skills with the appropriate ability modifier
        switch (skill.Name)
        {
            case "Acrobatics":
            case "Sleight of Hand":
            case "Stealth":
                baseBonus = DexterityModifier;
                break;
            case "Arcana":
            case "History":
            case "Investigation":
            case "Nature":
            case "Religion":
                baseBonus = IntelligenceModifier;
                break;
            case "Animal Handling":
            case "Insight":
            case "Medicine":
            case "Perception":
            case "Survival":
                baseBonus = WisdomModifier;
                break;
            case "Athletics":
                baseBonus = StrengthModifier;
                break;
            case "Deception":
            case "Intimidation":
            case "Performance":
            case "Persuasion":
                baseBonus = CharismaModifier;
                break;
            default:
                baseBonus = 0;
                break;
        }
        // Add proficiency bonus if the character is proficient in the skill
        if (skill.IsProficient)
            baseBonus += ProficiencyBonus;
        return baseBonus;
    }
}

// [Tool]
// [GlobalClass]
// public partial class Skill : Resource
// {
//     [Export] public string Name = "";
//     [Export] public bool IsProficient = false;
//     // Although bonus is computed from the ability modifier and proficiency, this field
//     // can be used to override or store additional modifiers.
//     [Export] public int Bonus = 0;
// }

// [Tool]
// [GlobalClass]
// public partial class Item : Resource
// {
//     [Export] public string ItemName = "";
//     [Export] public string Description = "";
//     [Export] public int Quantity = 1;
// }

// [Tool]
// [GlobalClass]
// public partial class Spell : Resource
// {
//     [Export] public string SpellName = "";
//     [Export] public string School = "";
//     [Export] public int Level = 0;
//     [Export] public string CastingTime = "";
//     [Export] public string Range = "";
//     [Export] public string Duration = "";
//     [Export] public string Description = "";
// }
