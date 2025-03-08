using System;
using System.Collections.Generic;
using Godot;
using System.Text.Json;
// using Godot.Collections;

public partial class Character : Node {
    public Character(){
        // A quick example of parsing some json
        var bard = JsonUtils.ParseJsonFile("user://data/class/class-bard.json");
        // GD.Print(bard["class"].ToString());
        var bardData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(bard["class"].ToString());

        // var bardDataInner = JsonSerializer.Deserialize<Dictionary<String, object>
        GD.Print(bardData[0].ToString());
        string name = bardData[0]["name"].ToString();
        GD.Print(name);
    }
}