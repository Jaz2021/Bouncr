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
        string source = bardData[0]["source"].ToString();
        GD.Print(name);
        GD.Print(source);
        string idk = bardData[0]["additionalSpells"].ToString();
        GD.Print(idk);
    }
}