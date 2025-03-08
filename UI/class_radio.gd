#extends Panel
extends Node
var checkboxes = []

func _ready():
	pass
	
func _on_radio_toggled(button_pressed,name,value):
	print(button_pressed,name,value)
	#var checkboxes = [
		#$HBoxContainer/VBoxContainer/CheckBox,
		#$HBoxContainer/VBoxContainer/CheckBox2,
		#$HBoxContainer/VBoxContainer/CheckBox3
		#]
		
	var x = 3  # Change this value to however many checkboxes you need
	for i in range(1, x + 1):  # Start from 1 to x
		var checkbox_path = "HBoxContainer/VBoxContainer/CheckBox" + str(i)
		checkboxes.append(checkbox_path)
	if(!button_pressed):
		return
	for i in checkboxes:
		var node = get_node(i) as Node
		if (node.name != name):
			i.button_pressed = false
		pass
	pass
