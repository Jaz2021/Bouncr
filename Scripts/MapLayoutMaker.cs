using Godot;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class MapLayoutMaker : FileDialog
{
	private Image image;
	[Export] public FileDialog fileDialog;
	[Export] public Button convertButton;
	[Export] public TextureRect imageDisplay;
	[Export] public Label successLabel;

	public override void _Ready()
	{
		convertButton.Pressed += () => OnOpenButtonPressed(); // Correct event binding
	}

	private void OnOpenButtonPressed()
	{
		fileDialog.CurrentDir = OS.GetSystemDir(OS.SystemDir.Downloads);
		fileDialog.PopupCentered();
		fileDialog.FileSelected += LoadImage;

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
	DrawGridOnImage();
	}

	private void DrawGridOnImage() 
	{
	int gridSize = 50;
	int width = image.GetWidth();
	int height = image.GetHeight();
	Color gridColor = new Color(0, 0, 0, 1); //black

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
		string filePath = Path.Combine(downloadsPath, "map_layout.png");

		// Save the image
		Error saveError = image.SavePng(filePath);
		if (saveError == Error.Ok)
		{
			GD.Print("Image saved to: " + filePath);
			UpdateTextureRect();
		}
		else
		{
			GD.Print("Failed to save image.");
		}
	}

	private void UpdateTextureRect()
	{
		ImageTexture texture = new ImageTexture();
		texture.SetImage(image);	

		if (imageDisplay != null)
		{
			imageDisplay.Texture = texture;
			successLabel.Text = "Map layout downloaded!";
		}
		else
		{
			GD.Print("TextureRect not assigned.");
		}
	}
}
