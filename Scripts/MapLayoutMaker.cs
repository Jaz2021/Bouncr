using Godot;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class MapLayoutMaker : FileDialog
{
	// private TextureRect textureRect;
	//private ImageTexture imageTexture;
	private Image image;
	//private Button openButton;
	[Export] public FileDialog fileDialog;
	[Export] public Button convertButton;

	public override void _Ready()
	{
		convertButton.Pressed += () => OnOpenButtonPressed(); // Correct event binding
		//fileDialog.FileSelected += OnFileSelected;
		
	}

	private void OnOpenButtonPressed()
	{
		fileDialog.PopupCentered(); // Opens the file dialog
	}

	public void LoadImage(string path) 
	{
		image = new Image();
		Error err = image.Load(path);
		if (err != Error.Ok) 
		{
			GD.Print("Failed to load image");
			return;
		}
		GD.Print("Made thru LoadImage");
	DrawGridOnImage();
	}

	private void DrawGridOnImage() 
	{
	int gridSize = 50;
	int width = image.GetWidth();
	int height = image.GetHeight();
	Color gridColor = new Color(1, 0, 0, 1); // red, use (0, 0, 0, 1) for black

	for (int x = 0; x < width; x += gridSize)
		{
			for (int y = 0; y < height; y++)
			{
				image.SetPixel(x, y, gridColor); // vertical line
			}
		}

		for (int y = 0; y < height; y += gridSize)
		{
			for (int x = 0; x < width; x++)
			{
				image.SetPixel(x, y, gridColor); // horizontal line
			}
		}
		SaveImageToDownloads();
	}

	// Save the modified image to the Downloads folder
	private void SaveImageToDownloads()
	{
		// Get the Downloads directory path
		string downloadsPath = Path.Combine(OS.GetUserDataDir(), "Downloads");

		// Ensure the folder exists
		if (!Directory.Exists(downloadsPath))
		{
			Directory.CreateDirectory(downloadsPath);
		}

		// Set the filename and path for the new image
		string filePath = Path.Combine(downloadsPath, "modified_image.png");

		// Save the image
		Error saveError = image.SavePng(filePath);
		if (saveError == Error.Ok)
		{
			GD.Print("Image saved to: " + filePath);
		}
		else
		{
			GD.Print("Failed to save image.");
		}
	}
}
