using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public static class JsonUtils
{
    public static Dictionary<string, object> ParseJsonFile(string filePath)
    {
        if (!FileAccess.FileExists(filePath))
        {
            GD.PrintErr($"File not found: {filePath}");
            return null;
        }

        var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
        if (file == null)
        {
            GD.PrintErr($"Failed to open file: {filePath}");
            return null;
        }

        string jsonText = file.GetAsText();
        file.Close();

        try
        {
            var jsonData = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonText);
            if (jsonData == null)
            {
                GD.PrintErr($"Invalid JSON format in file: {filePath}");
                return null;
            }
            return jsonData;
        }
        catch (JsonException e)
        {
            GD.PrintErr($"JSON parsing error: {e.Message}");
            return null;
        }
    }
}
