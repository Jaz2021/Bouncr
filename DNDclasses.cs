using System;
using System.Collections.Generic;
using Godot;
using System.Text.Json;
using System.Xml;
using System.Reflection.Metadata;
// using Godot.Collections;

public partial class DNDclasses : Node {
    public string name;
    public string source;
    public int numHitDie;
    public int hitDieType;
    public List<string> skillProficiencies;
    public string spellcastingAbility;
    public string preparedSpells;
    public List<int> cantripProgression;
    public List<string> armorProficiencies;
    public List<string> toolProficiencies;
    public List<string> weaponProficiencies;
    public List<string> skillChoices;
    public int numSkillChoices;
    public List<List<int>> spellProgression;
    public Dictionary<int, List<string>> classFeaturesByLevel;
    public DNDclasses(string name, string source, int numHitDie, int hitDieType, List<string> skillProficiencies, string spellcastingAbility, string preparedSpells, List<int> cantripProgression, List<string> armorProficiencies, List<string> toolProficiencies, List<string> weaponProficiencies, List<string> skillChoices, int numSkillChoices, List<List<int>> spellProgression, Dictionary<int, List<string>> classFeaturesByLevel){
        this.name = name;

    }
    private static void ReadDndClass(ref List<DNDclasses> classes, string filepath){
        var baseJson = JsonUtils.ParseJsonFile("user://data/class/" + filepath);
        // GD.Print(baseJson["class"].ToString());
        var classData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(baseJson["class"].ToString());

        // var classData = JsonSerializer.Deserialize<List<string>>(baseJson["class"].ToString());
        foreach(var classDataInstance in classData){
            // var classDataInstance = JsonSerializer.Deserialize<Dictionary<string, string>>(classDataInstance.ToString());
            var name = classDataInstance["name"].ToString();
            // GD.Print(name);
            var source = classDataInstance["source"].ToString();
            if (!classDataInstance.ContainsKey("hd")){
                // Skip any classes that don't have a hitdie these aren't playable
                continue;
            }
            var hitdieDict = JsonSerializer.Deserialize<Dictionary<string, object>>(classDataInstance["hd"].ToString());
            var numHitDie = 0;
            if(hitdieDict.ContainsKey("num")){
                numHitDie = hitdieDict["num"].ToString().ToInt();
            } else {
                numHitDie = hitdieDict["number"].ToString().ToInt();
            }
            // var numHitDie = hitdieDict["num"];
            int hitdieType = hitdieDict["faces"].ToString().ToInt();
            List<string> skillProficiencies = JsonSerializer.Deserialize<List<string>>(classDataInstance["proficiency"].ToString());
            string spellcastingAbility = "";
            if(classDataInstance.ContainsKey("spellcastingAbility")){
                spellcastingAbility = classDataInstance["spellcastingAbility"].ToString();
                // GD.Print(spellcastingAbility);
            }
            string preparedSpells = "";

            if(classDataInstance.ContainsKey("preparedSpells")){
                preparedSpells = classDataInstance["preparedSpells"].ToString();
            }
            List<int> cantripProgression = null;
            if (classDataInstance.ContainsKey("cantripProgression")){
                cantripProgression = JsonSerializer.Deserialize<List<int>>(classDataInstance["cantripProgression"].ToString());
            }
            var startingProficienciesDict = JsonSerializer.Deserialize<Dictionary<string, object>>(classDataInstance["startingProficiencies"].ToString());
            List<string> armorProficiencies = null;
            if(startingProficienciesDict.ContainsKey("armor")){
                armorProficiencies = new();
                var armorProficienciesRaw = JsonSerializer.Deserialize<List<object>>(startingProficienciesDict["armor"].ToString());
                foreach(var armor in armorProficienciesRaw){
                    if(armor.ToString().Contains('{')){
                        var deserializedArmor = JsonSerializer.Deserialize<Dictionary<string, object>>(armor.ToString());
                        armorProficiencies.Add(deserializedArmor["proficiency"].ToString());
                    } else {
                        armorProficiencies.Add(armor.ToString());
                    }
                }
            }
            List<string> weaponProficiencies = null;
            if(startingProficienciesDict.ContainsKey("weapons")){
                weaponProficiencies = new();
                var weaponproficienciesRaw = JsonSerializer.Deserialize<List<object>>(startingProficienciesDict["weapons"].ToString());
                foreach(var weapon in weaponproficienciesRaw){
                    if(weapon.ToString().Contains('{') && weapon.ToString().Contains(',')){
                        GD.Print(weapon);
                        var deserializedWapons = JsonSerializer.Deserialize<Dictionary<string, object>>(weapon.ToString());
                        weaponProficiencies.Add(deserializedWapons["proficiency"].ToString());
                    } else {
                        weaponProficiencies.Add(weapon.ToString());
                    }
                }
            }
            List<string> toolProficiencies = null;
            if(startingProficienciesDict.ContainsKey("tools")){
                toolProficiencies = JsonSerializer.Deserialize<List<string>>(startingProficienciesDict["tools"].ToString());
            }
            List<string> skillChoices = null;
            int numSkillChoices = 0;
            if(startingProficienciesDict.ContainsKey("skills")){
                var skillDict = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(startingProficienciesDict["skills"].ToString())[0];
                if(skillDict.ContainsKey("choose")){
                    var skillChoose = JsonSerializer.Deserialize<Dictionary<string, object>>(skillDict["choose"].ToString());
                    skillChoices = JsonSerializer.Deserialize<List<string>>(skillChoose["from"].ToString());
                    numSkillChoices = skillChoose["count"].ToString().ToInt();
                } else {
                    skillChoices = new();

                    numSkillChoices = skillDict["any"].ToString().ToInt();
                    skillChoices.Add("Any");

                }
            }
            List<List<int>> spellProgression = null;
            if(classDataInstance.ContainsKey("classTableGroups")){
                var tableGroups = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(classDataInstance["classTableGroups"].ToString());
                foreach(var table in tableGroups){
                    if(table.ContainsKey("title")){
                        if(table["title"].ToString() == "Spell Slots per Spell Level"){
                            spellProgression = JsonSerializer.Deserialize<List<List<int>>>(table["rowsSpellProgression"].ToString());

                        }
                    }
                }
            }
            Dictionary<int, List<string>> classFeaturesByLevel = null;
            if(classDataInstance.ContainsKey("classFeatures")){
                classFeaturesByLevel = new();
                var classFeatures = JsonSerializer.Deserialize<List<object>>(classDataInstance["classFeatures"].ToString());
                foreach(var feature in classFeatures){
                    var stringFeature = feature.ToString();
                    string f = "";
                    if(stringFeature.Contains('{')){
                        var featureDict = JsonSerializer.Deserialize<Dictionary<string, object>>(stringFeature);
                        f = featureDict["classFeature"].ToString();
                    } else {
                        f = stringFeature;
                    }
                    // GD.Print(f);
                    var splitFeature = f.Split('|');
                    int level =0;
                    try {
                        level = splitFeature[^1].ToInt();
                    } catch {
                        // Why is barbarian like this
                        level = splitFeature[^2].ToInt();
                    }
                    // var level = splitFeature[^1].ToInt();
                    // GD.Print(level);
                    var feat = splitFeature[0];
                    if(!classFeaturesByLevel.ContainsKey(level)){
                        classFeaturesByLevel.Add(level, new());
                    }
                    classFeaturesByLevel[level].Add(feat);
                }
            }
            classes.Add(new(name, source, numHitDie, hitdieType, skillProficiencies, spellcastingAbility, preparedSpells, cantripProgression, armorProficiencies, toolProficiencies, weaponProficiencies, skillChoices, numSkillChoices, spellProgression, classFeaturesByLevel));
        }
    }
    public static List<DNDclasses> GenerateClasses(){
        List<DNDclasses> output = new();
        var classIndex = JsonUtils.ParseJsonFile("user://data/class/index.json");
        // ReadDndClass(ref output, "class-bard.json");
        foreach (var c in classIndex) {
            GD.Print("Class: " + c.Key);
            ReadDndClass(ref output, c.Value.ToString());
        }
        GD.Print("Created Classes list");
        return output;
    }
}