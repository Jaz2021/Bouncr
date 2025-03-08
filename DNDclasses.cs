using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DnDClasses
{
    public class DnDClass
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public int Page { get; set; }
        public List<string> Proficiencies { get; set; }
        public int HitDiceNumber { get; set; }
        public int HitDiceFaces { get; set; }
        public List<string> StartingEquipment { get; set; }
        public List<string> ClassFeatures { get; set; }
        public Dictionary<string, object> AdditionalProperties { get; set; }
        public Subclass Subclass { get; set; }

        public override string ToString()
        {
            string additionalProps = string.Empty;
            foreach (var prop in AdditionalProperties)
            {
                additionalProps += $"{prop.Key}: {prop.Value}\n";
            }

            string subclassInfo = Subclass != null ? $"\nSubclass: {Subclass.Name}\nFeatures:\n- {string.Join("\n- ", Subclass.Features)}" : string.Empty;

            return $"Class: {Name}\nSource: {Source}\nHit Dice: {HitDiceNumber}d{HitDiceFaces}\nProficiencies: {string.Join(", ", Proficiencies)}\n{additionalProps}{subclassInfo}";
        }
    }

    public class Subclass
    {
        public string Name { get; set; }
        public List<string> Features { get; set; }
    }

    public class ClassParser
    {
        public static DnDClass ParseClass(string filePath)
        {
            var jsonData = JsonUtils.ParseJsonFile(filePath);
            if (jsonData == null)
                return null;

            string jsonString = JsonSerializer.Serialize(jsonData);
            var parsedClass = JsonSerializer.Deserialize<DnDClass>(jsonString);

            // Handle subclass if it exists
            if (jsonData.ContainsKey("subclass"))
            {
                string subclassJson = JsonSerializer.Serialize(jsonData["subclass"]);
                parsedClass.Subclass = JsonSerializer.Deserialize<Subclass>(subclassJson);
            }

            // Store any extra fields not part of the base class
            parsedClass.AdditionalProperties = new Dictionary<string, object>();
            foreach (var kvp in jsonData)
            {
                if (typeof(DnDClass).GetProperty(kvp.Key) == null && kvp.Key != "subclass")
                {
                    parsedClass.AdditionalProperties[kvp.Key] = kvp.Value;
                }
            }

            return parsedClass;
        }

        public static void Main(string[] args)
        {
            var artificer = ParseClass("res://class-artificer.json");
            if (artificer != null)
                GD.Print(artificer.ToString());

            var barbarian = ParseClass("res://class-barbarian.json");
            if (barbarian != null)
                GD.Print(barbarian.ToString());
        }
    }
}
