using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Godot;

public partial class Spell : Node {
    public enum School {
        Evocation,
        Abjuration,
        Transmutation,
        Conjuration,
        None
    }

    private static School ConvertToSchool(string input) {
        return input switch {
            "V" => School.Evocation,
            "A" => School.Abjuration,
            "T" => School.Transmutation,
            "C" => School.Conjuration,
            _ => School.None
        };
    }
    public string name;
    public int level;
    public School school;
    public string castTime;
    public string rangeType;
    public int rangeAmount;
    public string rangeUnit;
    public List<string> components;
    public string duration;
    public string description;
    public string higherLevelDescription;
    public List<string> availableClasses;

    public Spell(string name, int level, School school, string castTime, string rangeType, int rangeAmount, string rangeUnit, List<string> components, string duration, string description, string higherLevelDescription, List<string> availableClasses ) {
        // Constructor logic
        // GD.Print("Created spell with name: " + name);
        this.name = name;
        this.level = level;
        this.school = school;
        this.castTime = castTime;
        this.rangeAmount = rangeAmount;
        this.rangeType = rangeType;
        this.rangeUnit = rangeUnit;
        this.components = components;
        this.duration = duration;
        this.description = description;
        this.higherLevelDescription = higherLevelDescription;
        this.availableClasses = availableClasses;

    }
    private static void ReadSpellBook(ref List<Spell> spells, string fileLocation) {
        // GD.Print("Reading spellbook: " + fileLocation);
        var spellbookData = JsonUtils.ParseJsonFile("user://data/spells/" + fileLocation);
        
        // Deserialize into an object that matches the file structure
        // var spellbookData = JsonSerializer.Deserialize<Dictionary<string, object>>(spellbookJson.ToString());
        
        if (!spellbookData.ContainsKey("spell")) {
            GD.PrintErr($"No 'spell' key found in {fileLocation}");
            return;
        }

        // Extract spell list
        var spellsList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(spellbookData["spell"].ToString());

        foreach (var spelldata in spellsList) {
            var name = spelldata["name"].ToString();
            // GD.Print("Checking spell: " + name);
            var level = spelldata["level"].ToString().ToInt();
            var school = ConvertToSchool(spelldata["school"].ToString());

            // Casting Time
            var timeDict = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(spelldata["time"].ToString())[0];
            var castTime = $"{timeDict["number"]} {timeDict["unit"]}";

            // Range
            var rangeDict = JsonSerializer.Deserialize<Dictionary<string, object>>(spelldata["range"].ToString());
            var rangeType = rangeDict["type"].ToString();
            var rangeAmount = 0;
            var rangeUnit = "";

            if (rangeDict.ContainsKey("distance")) {
                var rangeDisDict = JsonSerializer.Deserialize<Dictionary<string, object>>(rangeDict["distance"].ToString());
                if (rangeDisDict.ContainsKey("amount")) {
                    rangeAmount = rangeDisDict["amount"].ToString().ToInt();
                }
                if (rangeDisDict.ContainsKey("type")) {
                    rangeUnit = rangeDisDict["type"].ToString();
                }
            }

            // Components
            List<string> components = new();
            var componentsDict = JsonSerializer.Deserialize<Dictionary<string, object>>(spelldata["components"].ToString());
            if (componentsDict.ContainsKey("v")) components.Add("Verbal");
            if (componentsDict.ContainsKey("s")) components.Add("Somatic");
            if (componentsDict.ContainsKey("m")) {
                if(componentsDict["m"].ToString().Contains('{')){
                    var material = JsonSerializer.Deserialize<Dictionary<string, object>>(componentsDict["m"].ToString());
                    components.Add($"Material ({material["text"]})");
                } else {
                    components.Add($"Material ({componentsDict["m"].ToString()})");
                }
                
            }

            // Duration
            var durationDict = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(spelldata["duration"].ToString())[0];
            var duration = durationDict["type"].ToString();
            if (duration == "timed" && durationDict.ContainsKey("duration")) {
                var durationDetails = JsonSerializer.Deserialize<Dictionary<string, object>>(durationDict["duration"].ToString());
                duration = $"{durationDetails["amount"]} {durationDetails["type"]}";
            }

            // Spell Description
            // var description = string.Join("\n", JsonSerializer.Deserialize<List<string>>(spelldata["entries"].ToString()));

            // Higher Level Description
            // string higherLevelDescription = "";
            // if (spelldata.ContainsKey("entriesHigherLevel")) {
            //     var higherEntries = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(spelldata["entriesHigherLevel"].ToString());
            //     higherLevelDescription = string.Join("\n", JsonSerializer.Deserialize<List<string>>(higherEntries[0]["entries"].ToString()));
            // }
            // GD.Print(name);
            List<string> availableClasses = new();

            var spellClassesjson = JsonUtils.ParseJsonFile("user://data/spells/sources.json");
            GD.Print(spelldata["source"].ToString());
            foreach(var source in spellClassesjson){
                // GD.Print(source.Value.ToString());
                var spellData = JsonSerializer.Deserialize<Dictionary<string, object>>(source.Value.ToString());
                foreach(var spell in spellData) {
                    if(spell.Key == name){
                        // GD.Print(spell.Value);
                        var classData = JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, string>>>>(spell.Value.ToString());
                        List<Dictionary<string, string>> classesList;
                        if(classData.ContainsKey("class")){
                            classesList = classData["class"];

                        } else {
                            // This would be to handle subclass availability
                            continue;
                        }
                        foreach(var c in classesList){
                            availableClasses.Add(c["name"]);
                            // GD.Print(c["name"]);
                        }
                        // var classes = JsonSerializer.Deserialize<Dictionary<string, object>>(spell.Value.ToString());
                        // foreach(var c in classes){
                        //     availableClasses.Add(c["name"].ToString());
                        //     GD.Print(c["name"].ToString());
                        // }
                    }
                }
            }
            // if(spellClassesjson.ContainsKey(spelldata["source"].ToString())){
            //     var spellBook = JsonSerializer.Deserialize<Dictionary<string, object>>(spellClassesjson[spelldata["source"].ToString()].ToString());

            //     if(spellbookData.ContainsKey("class")){
            //         availableClasses = new();
            //         var spellClassData = JsonSerializer.Deserialize<List<Dictionary<string,object>>>(spellBook["class"].ToString());
            //         foreach(var classJson in spellClassData){
                        
            //             availableClasses.Add(classJson["name"].ToString());
            //             GD.Print(classJson["name"].ToString());
            //         }
            //     }
            // }
            
            
            spells.Add(new Spell(name, level, school, castTime, rangeType, rangeAmount, rangeUnit, components, duration, "", "", availableClasses));
        }
    }


    public static List<Spell> GenerateSpells() {
        List<Spell> output = new();
        var spellBookIndex = JsonUtils.ParseJsonFile("user://data/spells/index.json");

        foreach (var spellbook in spellBookIndex) {
            ReadSpellBook(ref output, spellbook.Value.ToString());
        }
        GD.Print("Created spells list");
        return output;
    }
}
