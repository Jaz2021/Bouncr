using System;
using System.Collections.Generic;
using Godot;
using System.Text.Json;
// using Godot.Collections;

public partial class Character : Node {
    public DNDclasses c;
    public Races race;
    public Subclasses subclass;
    public List<Spell> spells;
    public int Int = 8;
    public int Dex = 8;
    public int Con = 8;
    public int Wis = 8;
    public int Cha = 8;
    public int Str = 8;
    public Character(DNDclasses c, Races race, Subclasses subclass, List<Spell> spells){
        Int += race.raceInt;
        Dex += race.raceDex;
        Con += race.raceCon;
        Cha += race.raceCha;
        Wis += race.raceWis;
        Str += race.raceStr;
        this.c = c;
        this.race = race;
        this.subclass = subclass;
        this.spells = spells;
    }

}