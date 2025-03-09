using Godot;
using System;

public partial class SwapScenes : Node
{
	// Assign the button that will trigger the scene change.
	[Export]
	public Button SceneSwitchButton { get; set; }

	// Assign the target scene (PackedScene) to switch to.
	[Export]
	public string TargetScene { get; set; }

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

	private void ChangeScene(string newScene)
	{
		if (newScene == null)
		{
			GD.PrintErr("Target scene not assigned.");
			return;
		}
		// Switch to the new scene safely.
		GetTree().ChangeSceneToFile(newScene);
	}
}
