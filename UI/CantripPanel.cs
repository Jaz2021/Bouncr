using Godot;
using System;
using System.Collections.Generic;

public partial class CantripPanel : Panel
{
    private List<string> checkboxes = new List<string>();

    public override void _Ready()
    {
        // Initialization if needed
    }

    public void OnRadioToggled(bool buttonPressed, string name, int value)
    {
        GD.Print(buttonPressed, " ", name, " ", value);

        int x = 3; // Change this value to however many checkboxes you need
        checkboxes.Clear(); // Ensure the list is empty before adding new checkboxes

        for (int i = 1; i <= x; i++) // Start from 1 to x
        {
            string checkboxPath = $"HBoxContainer/VBoxContainer/CheckBox{i}";
            checkboxes.Add(checkboxPath);
        }

        if (!buttonPressed)
            return;

        foreach (string checkboxPath in checkboxes)
        {
            Node node = GetNode<Node>(checkboxPath);
            if (node is CheckBox checkbox && checkbox.Name != name)
            {
                checkbox.ButtonPressed = false;
            }
        }
    }
}


