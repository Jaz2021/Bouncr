using Godot;
using System;

public partial class ButtonManager : Node
{
    // Exported PackedScene properties for the scenes
    [Export]
    public PackedScene CreateScene { get; set; }

    [Export]
    public PackedScene LoadScene { get; set; }

    public override void _Ready()
    {
        // Use the correct relative path from the current node to Button.
        // Button createButton = GetNode<Button>("../VboxC/CreateButton");
        // Button loadButton = GetNode<Button>("../VboxC/LoadButton");
        Button quitButton = GetNode<Button>("../VboxC/QuitButton");
        
        // Connect the button's 'pressed' signal to the appropriate methods
        // createButton.Pressed += OnCreateButtonPressed;
        // loadButton.Pressed += OnLoadButtonPressed;
        quitButton.Pressed += Quit;
    }

    private void OnCreateButtonPressed()
    {
        ChangeScene(CreateScene);
    }

    private void OnLoadButtonPressed()
    {
        ChangeScene(LoadScene);
    }

    private void ChangeScene(PackedScene newScene)
    {
        if (newScene == null)
        {
            GD.PrintErr("No scene assigned.");
            return;
        }

        // This will safely change the scene without manually removing nodes
        GetTree().ChangeSceneToPacked(newScene);
    }
    private void Quit()
    {
        GD.Print("Button was pressed!");
        GetTree().Quit();
    }
}
