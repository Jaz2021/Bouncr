extends VBoxContainer

#extends Node

#@onready var container = $HBoxContainer/VBoxContainer  # The parent node where checkboxes will be added



func _ready() -> void:
	
	var class_keys = get_class_keys()
	
	var j = 0
	for i in get_class_keys():  # Create 3 checkboxes
		var checkbox = CheckBox.new()  # Instantiate a new CheckBox
		checkbox.name = i  # Give it a unique name
		checkbox.text = i  # Set the label text
		j = j + 1
		
		checkbox.pressed.connect(_on_checkbox_toggled.bind(checkbox))  # Connect the signal
		add_child(checkbox)  # Add checkbox to self (current node)
	
	# Optional: Add some spacing/positioning f	or each checkbox
	#checkbox.position.y = i * 30  # Stack checkboxes vertically with some spacing

# Function to handle checkbox toggling
func _on_checkbox_toggled(button: CheckBox) -> void:
	for child in get_children():
		if child is CheckBox and child != button:
			child.button_pressed = false  # Uncheck other checkboxes
			
func get_class_keys() -> Array:
	
	var file = FileAccess.open("user://data/class/index.json", FileAccess.READ)
	if file:
		var json_text = file.get_as_text()
		file.close()
		
		# Parse JSON
		var json = JSON.new()
		var parse_result = json.parse(json_text)
		
		if parse_result == OK:
			var class_dict = json.get_data()
			
			# Return the keys as an array
			return class_dict.keys()
		else:
			print("JSON parsing failed.")
	else:
		print("Failed to open file.")
	
	return []  # Return an empty array if something fails
