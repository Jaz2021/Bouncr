#extends Panel
extends Node

func _ready():
	pass
	
func _on_radio_toggled(button_pressed,name,value):
	print(button_pressed,name,value)
	var checkboxes = [
		$HBoxContainer/VBoxContainer/CheckBox,
		$HBoxContainer/VBoxContainer/CheckBox2,
		$HBoxContainer/VBoxContainer/CheckBox3
		]
	if(!button_pressed):
		return
	for i in checkboxes:
		if (i.name != name):
			i.button_pressed = false
		pass
	pass
