using System;
using System.Collections.Generic;
using Godot;
using System.Text.Json;
using System.Linq;

public partial class Subclasses : Node
{
    private string name;
    private string classSource;
    private Dictionary<int, List<string>> subclassFeaturesbyLevel;

    public Subclasses(string name, string classSource, Dictionary<int, List<string>> subclassFeaturesbyLevel)
    {
        this.name = name;
        this.classSource = classSource;
        this.subclassFeaturesbyLevel = subclassFeaturesbyLevel;
    }
    public static List<Subclasses> generateSubclassList(Dictionary<string, object> jsonFrom)
    {
        List<Subclasses> subclassList = new();

        var listData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonFrom["subclass"].ToString());

        foreach (var subclassEntry in listData)
        {
            var name = subclassEntry["name"].ToString();
            var classSource = subclassEntry["classSource"].ToString();
            if (subclassEntry.ContainsKey("_copy")){
                continue;
                // We can just ignore subclasses that are copies of other subclasses
            }

            Dictionary<int, List<string>> subclassFeaturesbyLevel = null;
            if (subclassEntry.ContainsKey("subclassFeatures"))
            {
                subclassFeaturesbyLevel = new();
                var subclassFeatures = JsonSerializer.Deserialize<List<object>>(subclassEntry["subclassFeatures"].ToString());

                foreach(var feature in subclassFeatures)
                {
                    var scFeature = feature.ToString();
                    var splitFeature = scFeature.Split('|');

                    int level = 0;
                    level = splitFeature[^1].ToInt();

                    var feat = splitFeature[0];

                    if (!subclassFeaturesbyLevel.ContainsKey(level))
                    {
                        subclassFeaturesbyLevel.Add(level, new());
                    }

                    subclassFeaturesbyLevel[level].Add(feat);
                }
            }
            subclassList.Add(new(name, classSource, subclassFeaturesbyLevel));
        }

        
        return subclassList;
    }
}