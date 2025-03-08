using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Skill : Resource
{
    [Export] public string Name = "";
    [Export] public bool IsProficient = false;
    [Export] public int Bonus = 0;
}