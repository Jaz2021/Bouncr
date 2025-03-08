using Godot;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO.Enumeration;

public partial class downloadJson : Node
{

	[Export]
	private string repo = "5etools-mirror-1/5etools-mirror-1.github.io";
	private static string url = "https://api.github.com/repos/";
    private static string ender = "/contents/data";
	public static List<Action> jsonReady;
	private string rawVer = "https://raw.githubusercontent.com/";
	// Called when the node enters the scene tree for the first time.


	// Regex regex = new Regex(@"\""path\"":\""((?:(?!"").)*?/(?:(?!"").)*?)\"",\""contentType\"":\""directory\"""); //Find directories out of data html
	// Regex regex = new Regex(@"data\/((?:(?!\"").)*?\.json)"); //Find files out of data directory and others
	// Regex r = new Regex(@"^(.+)\/[^\/]+\.json$");
	// string directory = r.Match(m).Groups[1].Value; //Combine to get the directory out of a json file name
	HttpRequest htmlReq;
	[Export] private NodePath labelPath;
	[Export] private NodePath loadingBarPath;
	private ColorRect loadingBar;
	private Label outputLabel;
	private const int Requesters = 25;
	StoreFileLocation[] jsonReqs = new StoreFileLocation[Requesters]; // Running 10 downloaders in parallel, the amount can be configured
	public override void _Ready()
	{
		htmlReq = new HttpRequest();
		AddChild(htmlReq);
		htmlReq.RequestCompleted += htmlComplete;
		for(int i = 0; i < Requesters; i++){
			var req = new StoreFileLocation(this);
			jsonReqs[i] = req;
			AddChild(req);
			req.RequestCompleted += req.jsonComplete;
		}
		directories.Add(url+repo+ender);
		// outputLabel.Text = currentStep;
		findDirectories();
	}

	private List<string> directories = new List<string>();
	private List<string> jsons = new List<string>();
	private int currentIndex = 0;
	private string currentStep = "Finding directories: ";
	private void findDirectories(){
        // GD.Print(directories[currentIndex]);
		
		currentIndex += 1;
		if(directories.Count >= currentIndex){
			GD.Print("Requesting");
       		htmlReq.Request(directories[currentIndex - 1]);
		} else{
			GD.Print("Done finding");
			downloadJsons();
		}
		
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private void htmlComplete(long result, long responseCode, string[] headers, byte[] body){	
		GD.Print("Got json");
		if(Encoding.UTF8.GetString(body).Length < 700){
			GD.Print(Encoding.UTF8.GetString(body));
		}
		var json = Json.ParseString(Encoding.UTF8.GetString(body)).AsGodotArray();
		// GD.Print(json[1]);
        foreach (var item in json)
        {
            // GD.Print("Item: " + item);
            if(item.AsGodotDictionary()["name"].AsString().Contains(".json")){
                jsons.Add(item.AsGodotDictionary()["download_url"].AsString());
                

            } else{
				GD.Print(item.AsGodotDictionary()["url"].AsString());

                directories.Add(item.AsGodotDictionary()["url"].AsString());
            }
        }
		findDirectories();

	}
	private int completedJsons = Requesters;
	private void downloadJsons(){
		if(completedJsons != Requesters){
			outputLabel.Text = "Downloading json files: " + (currentIndex + completedJsons) + "/" + jsons.Count;
			loadingBar.AnchorRight = 0.2f + MathF.Round(((float)currentIndex + completedJsons) / jsons.Count * 0.6f, 3);
			GD.Print(currentIndex + completedJsons);
			return;
		}
		GD.Print("Running a batch of json downloaders");
		completedJsons = 0;
		if(currentIndex < jsons.Count){
			currentIndex += Requesters;
			outputLabel.Text = "Downloading json files: " + currentIndex + "/" + jsons.Count;
			GD.Print("Downloading next " + Requesters);
			for(int i = 1; i <= Requesters; i++){
				// GD.Print(currentIndex - i);
				if(currentIndex - i < jsons.Count){
					GD.Print("Downloading " + jsons[currentIndex - i]);
					// jsonReqs[i - 1].DownloadFile = "user://" + jsons[currentIndex - 1];
					jsonReqs[i - 1].location = jsons[currentIndex - i];
					// GD.Print(jsons[currentIndex - i]);
					jsonReqs[i - 1].Request(jsons[currentIndex - i]);
				} else {
					completedJsons++;
					// If it shouldn't download anything increment completedJsons so that we actually know when we're done
				}
			}
		} else{
			// Downloaded all json files, we're done now
			// GD.Print("One finished");

			if(!finishedRan){
				finished();
			}
		}
	}
	private Dictionary<string, string> jsonDict = new Dictionary<string, string>();
	public void addToDict(string location, string json){
		jsonDict.Add(location, json);
		completedJsons += 1;
		downloadJsons();
	}
	private bool finishedRan = false;
	private async void finished(){
		finishedRan = true;
		// GD.Print("Finished collecting jsons");
		loadingBar.AnchorRight = 0.9f;
		outputLabel.Text = "Saving json data to disk";
		foreach(var file in jsonDict){
			Regex reg = new Regex("https://.*?(/data/.*)");
			string FileName = reg.Match(file.Key).Groups[1].ToString();
			GD.Print(FileName);

			var fa = FileAccess.Open("user://" + FileName, FileAccess.ModeFlags.Write);
			fa.StoreString(file.Value);
			fa.Close();
		}
		loadingBar.AnchorRight = 1f;
		outputLabel.Text = "Done!";
		 await ToSignal(GetTree().CreateTimer(5), "timeout");
		GetTree().Root.RemoveChild(this);

	}
}
