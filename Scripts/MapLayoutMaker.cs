using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class MapLayoutMaker : FileDialog
{
	// private TextureRect textureRect;
	private ImageTexture imageTexture;
	private Image image;
	private Button openButton;
	[Export] public FileDialog fileDialog;
	[Export] public Button convertButton;

	public override void _Ready()
	{
		// Get nodes
		//textureRect = GetNode<TextureRect>("TextureRect");
		//openButton = GetNode<Button>("OpenButton");

		// Connect button press signal
		convertButton.Pressed += () => OnOpenButtonPressed(); // Correct event binding

		// Connect file dialog selection signal
		//fileDialog.FileSelected += OnFileSelected;
	}

	private void OnOpenButtonPressed()
	{
		fileDialog.PopupCentered(); // Opens the file dialog
		//GD.Print("hello");
	}

	//public void LoadImage(string path) 
	//{
		//image = new Image();
		//Error err = image.Load(path);
		//if (err != Error.Ok) 
		//{
			//GD.PrintErr("Failed to load image");
			//return;
		//}
	//DrawGridOnImage();
	//}
	//private void DrawGridOnImage() 
	//{
	//// int gridSize = 50;
	//// int width = image.GetWidth();
	//// int height = image.GetHeight();
	//// Color gridColor = new Color(1, 0, 0, 1); // red, use (0, 0, 0, 1) for black
//
	//// for (int x = 0; x < width; x += gridSize)
	//// 	{
	//// 		for (int y = 0; y < height; y++)
	//// 		{
	//// 			image.SetPixel(x, y, gridColor); // vertical line
	//// 		}
	//// 	}
//
	//// 	for (int y = 0; y < height; y += gridSize)
	//// 	{
	//// 		for (int x = 0; x < width; x++)
	//// 		{
	//// 			image.SetPixel(x, y, gridColor); // horizontal line
	//// 		}
	//// 	}
	//// 	imageTexture = new ImageTexture();
	//// 	imageTexture.SetImage(image);
	//// 	textureRect.Texture = imageTexture;
	//}
}
