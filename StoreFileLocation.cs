using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public partial class StoreFileLocation : HttpRequest
{
	public string location;
	// Called when the node enters the scene tree for the first time.
	private DownloadData dad;

	public StoreFileLocation(DownloadData father){
		// GD.Print("I came into being");
		dad = father;
		// Store the controller class
	}
	public void jsonComplete(long result, long responseCode, string[] headers, byte[] body){
		GD.Print("Got a json file");
		string json = Encoding.UTF8.GetString(body);
		// FileAccess file = FileAccess.Open("user://" + jsons[currentIndex - 1], FileAccess.ModeFlags.Write);
		// file.StoreString(json);
		// file.Close();
		dad.addToDict(location, json);
	}
}