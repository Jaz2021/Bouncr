using Godot;
using System;

public partial class MainScene : Node
{
    // Assign the button that will trigger the scene change.
    [Export]
    public Button SceneSwitchButton { get; set; }

    // Assign the target scene (PackedScene) to switch to.
    [Export]
    public PackedScene TargetScene { get; set; }

    public override void _Ready()
    {
        if (SceneSwitchButton == null)
        {
            GD.PrintErr("SceneSwitchButton not assigned!");
            return;
        }
        // Use a lambda to connect the Pressed signal.
        SceneSwitchButton.Pressed += () => ChangeScene(TargetScene);
    }

    private void ChangeScene(PackedScene newScene)
    {
        GetTree().ChangeSceneToFile("res://UI/MainMenu.tscn");
    }
}
