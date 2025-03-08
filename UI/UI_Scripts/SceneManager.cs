using Godot;
using System;

public partial class SceneManager : Node
{
    /// <summary>
    /// Switches to a new scene given its file path.
    /// For Godot 4 you can use ChangeSceneToFile().
    /// </summary>
    /// <param name="scenePath">The resource path to the new scene (e.g. "res://Scenes/Level1.tscn")</param>
    public void SwitchScene(string scenePath)
    {
        Error err = GetTree().ChangeSceneToFile(scenePath);
        if (err != Error.Ok)
        {
            GD.PrintErr($"Failed to change scene to {scenePath} - Error: {err}");
        }
    }

    /// <summary>
    /// Toggles the visible state of a CanvasItem (such as a Control or Sprite2D).
    /// </summary>
    /// <param name="node">The node to toggle. It must inherit from CanvasItem.</param>
    public void ToggleNodeVisibility(Node node)
    {
        if (node is CanvasItem canvasItem)
        {
            canvasItem.Visible = !canvasItem.Visible;
        }
        else
        {
            GD.PrintErr("ToggleNodeVisibility: The node does not inherit from CanvasItem and cannot be toggled.");
        }
    }
}
