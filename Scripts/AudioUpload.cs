using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class AudioUpload : FileDialog
{
    // private TextureRect textureRect;
    private ImageTexture imageTexture;
    private Image image;
    private Button openButton;
    [Export] public FileDialog fileDialog;
    [Export] public Button convertButton;
    [Export] public AudioStreamPlayer audioPlayer;

    public override void _Ready()
    {
        // Dynamically create the AudioStreamPlayer
        audioPlayer = new AudioStreamPlayer();
        AddChild(audioPlayer);

        // Connect the button event
        convertButton.Pressed += () => OnOpenButtonPressed();
        fileDialog.FileSelected += LoadMusic;
    }

    private void OnOpenButtonPressed()
    {
        fileDialog.PopupCentered();
    }

    public void LoadMusic(string path)
    {
        AudioStream audioStream = (AudioStream)ResourceLoader.Load(path);

        if (audioStream == null)
        {
            GD.PrintErr("Failed to load audio file: " + path);
            return;
        }

        // Play the audio
        audioPlayer.Stream = audioStream;
        audioPlayer.Play();
        GD.Print("Playing: " + path);
    }
}