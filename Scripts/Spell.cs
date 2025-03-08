// using System.Collections.Generic;
// using System.Text.Json;
// using Godot;
// public partial class Spell : Node {
//     public enum School {
//         Evocation,
//         Abjuration,
//         None
//     }
//     private static School convertToSchool(string input) {
//         switch(input){
//             case "V":
//                 return School.Evocation;
//             case "A":
//                 return School.Abjuration;
//         } 
//         return School.None;
//     }
//     Spell(string name, int level, School school){

//     }
//     private static void ReadSpellBook(ref List<Spell> spells, string fileLocation){
//         var spellbookJson = JsonUtils.ParseJsonFile("users://data/spells/" + fileLocation);
//         var spellsList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(spellbookJson.ToString());
//         foreach(var spelldata in spellsList){
//             var name = spelldata["name"];
//             var level = spelldata["level"];
//             var schoolStr = spelldata["school"];
//             var school = convertToSchool(schoolStr);
//             var timeDict = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(spelldata["time"].ToString())[0];
//             var cast_time = timeDict["number"];
//             var cast_unit = timeDict["unit"];
//             var rangeDict = JsonSerializer.Deserialize<Dictionary<string, string>>(spelldata["range"]);
//             var rangeType = rangeDict["type"];
//             var rangeDisDict = JsonSerializer.Deserialize<Dictionary<string, string>>(rangeDict["distance"]);
//             string rangeDistType = "";
//             if (rangeDisDict.ContainsKey("type")){
//                 rangeDistType = rangeDisDict["type"];
//             }
//             int rangeDist = 0;
//             if (rangeDisDict.ContainsKey("amount")){
//                 rangeDist = rangeDisDict["amount"].ToInt();
//             }
//             List<string> components = new();
//             var componentsDict = JsonSerializer.Deserialize<Dictionary<string, string>>(spelldata[])
//         }
//     }
//     public static List<Spell> GenerateSpells(){
//         List<Spell> output = new();
//         var spellBookIndex = JsonUtils.ParseJsonFile("users://data/spells/index.json");
//         foreach(var spellbook in spellBookIndex){
//             ReadSpellBook(ref output, spellbook.Value.ToString());
//         }

//         return output;
//     }
// }

