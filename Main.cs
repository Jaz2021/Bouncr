using Godot;
using System;

public partial class Main : Node
{
    [Export] private LineEdit repoEditor;
    [Export] private PackedScene DownloadDataScene;
    [Export] private Control currentMenu;
    [Export] private PackedScene mainMenu;

    public override void _Ready()
    {
        if(Global.instance == null){
            Global.instance = new();
        }

    }
    public void DownloadButtonPressed(){
        var repo = repoEditor.Text;
        DownloadData dd = DownloadDataScene.Instantiate<DownloadData>();
        // var dd = ddScene.GetChild<DownloadData>(0);
        currentMenu.QueueFree();
        // GD.Print("Download pressed");

        GetChild(0).AddChild(dd);

        dd.Visible = true;
        // GD.Print(dd.GetParent().Name);
        // GD.Print(GetChild(0).Name);
        // GD.Print("Download pressed");
        dd.Position = new Vector2(0, 0);
        currentMenu = dd;
        // dd.down
        // currentMenu = dd;
        dd.Download(repo, ParseData);



    }
    public void ParseButtonPressed(){
        
        ParseData();
    }
    public void ParseData(){
        currentMenu.QueueFree();
        Global.instance.classes = DNDclasses.GenerateClasses();
        Global.instance.races = Races.generateRaceList();
        Global.instance.spells = Spell.GenerateSpells(); 
        GD.Print("Classes initialized!");

        var mm = mainMenu.Instantiate<Control>();
        GetChild(0).AddChild(mm);
    }
}
