using System;
using System.Collections.Generic;
using Godot;
using System.Text.Json;
// using Godot.Collections;

public partial class DNDclasses : Node {
    public DNDclasses(){
        // A quick example of parsing some json
        var bard = JsonUtils.ParseJsonFile("user://data/class/class-bard.json");
        // GD.Print(bard["class"].ToString());
        var bardData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(bard["class"].ToString());

        // var bardDataInner = JsonSerializer.Deserialize<Dictionary<String, object>
        
        GD.Print(bardData[0].ToString());
        string name = bardData[0]["name"].ToString();
        string primaryAbility = bardData[0]["spellcastingAbility"].ToString();

        var hdJson = JsonSerializer.Serialize(bardData[0]["hd"]);
        Dictionary<string, object> hd = JsonSerializer.Deserialize<Dictionary<string, object>>(hdJson);
        string HitPointDie = hd["number"].ToString();

        var proficiencyJson = JsonSerializer.Serialize(bardData[0]["proficiency"]);
        var proficiencies = JsonSerializer.Deserialize<List<string>>(proficiencyJson);

          
        var startingProficiencies = JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(bardData[0]["startingProficiencies"]));
        var skills = JsonSerializer.Deserialize<List<Dictionary<string,int >>>(JsonSerializer.Serialize(startingProficiencies["skills"]));

        string proficiencySkills = skills[0]["any"].ToString();

        
        var weapons = JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(startingProficiencies["weapons"]));
        string weapon = weapons[0].ToString();
        
        List<string> cleanweapons = new List<string>();
        
        foreach (var item in weapons)
        {
            if (item[0] != '{'){
                cleanweapons.Add(item);
            }
        }

        



       
        GD.Print("Primary Ability: " + primaryAbility + "\n\n" +
            "Hit Point Die: D" + HitPointDie + "per " + name + " level" + "\n" +
            "Hit points at level 1: " + HitPointDie + " + Con. modifier \n" +
            "Hit Points per additional Bard Level: D" + HitPointDie + "+ your Con. modifier\n" +
            "Saving Throw Proficiencies: " + proficiencies[0] + ", "+ proficiencies[1] +
            "\n\n" + "Skill proficiencies: Choose "+ proficiencySkills +
            "Weapon Proficiencies: " + weapon[0]);

       
        GD.Print(proficiencySkills);
        

    }
}