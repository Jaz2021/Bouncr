extends VBoxContainer

#extends Node

#@onready var container = $HBoxContainer/VBoxContainer  # The parent node where checkboxes will be added

func _ready() -> void:
	
	for i in range(3):  # Create 3 checkboxes
		var checkbox = CheckBox.new()  # Instantiate a new CheckBox
		checkbox.name = "CheckBox" + str( i + 1)  # Give it a unique name
		checkbox.text = "Option " + str(i + 1)  # Set the label text
		checkbox.pressed.connect(_on_checkbox_toggled.bind(checkbox))  # Connect the signal
		add_child(checkbox)  # Add checkbox to self (current node)
	
	# Optional: Add some spacing/positioning f	or each checkbox
	#checkbox.position.y = i * 30  # Stack checkboxes vertically with some spacing

# Function to handle checkbox toggling
func _on_checkbox_toggled(button: CheckBox) -> void:
	for child in get_children():
		if child is CheckBox and child != button:
			child.button_pressed = false  # Uncheck other checkboxes
