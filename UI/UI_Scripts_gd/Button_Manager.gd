extends Node

# References to the buttons
@onready var race_button: Button = $"../PanelContainer/HBoxContainer/VBoxContainer/Race"
@onready var class_button: Button = $"../PanelContainer/HBoxContainer/VBoxContainer/Class"
@onready var sub_class_button: Button = $"../PanelContainer/HBoxContainer/VBoxContainer/Sub-Class"
@onready var button_4: Button = $"../PanelContainer/HBoxContainer/VBoxContainer/Button4"
@onready var button_5: Button = $"../PanelContainer/HBoxContainer/VBoxContainer/Button5"
@onready var button_6: Button = $"../PanelContainer/HBoxContainer/VBoxContainer/Button6"

# References to the panels
@onready var race_panel: Panel = $"../PanelContainer/HBoxContainer/Race_Panel"
@onready var class_panel: Panel = $"../PanelContainer/HBoxContainer/Class_Panel"
@onready var sub_class_panel: Panel = $"../PanelContainer/HBoxContainer/Sub-Class_Panel"
@onready var main: Panel = $"../PanelContainer/HBoxContainer/Main"
@onready var spell_panel: Panel = $"../PanelContainer/HBoxContainer/Spell_Panel"
@onready var cantrip_panel: Panel = $"../PanelContainer/HBoxContainer/Cantrip_Panel"
@onready var background_panel: Panel = $"../PanelContainer/HBoxContainer/Background_Panel"

# Panels in the container (can be expanded or modified as needed)
@onready var all_panels: Array = [
	race_panel,
	class_panel,
	main,
	sub_class_panel,
	spell_panel,
	cantrip_panel,
	
]

# Called when the node is ready
func _ready() -> void:
	# Connect the button pressed signals to their respective functions
	race_button.pressed.connect(_on_race_button_pressed)
	class_button.pressed.connect(_on_class_button_pressed)
	sub_class_button.pressed.connect(_on_sub_class_button_pressed)
	button_4.pressed.connect(_on_spell_button_pressed)
	button_5.pressed.connect(_on_cantrip_button_pressed)
	#button_6.pressed.connect(_on_background_button_pressed)


func _on_cantrip_button_pressed() -> void:
	_show_panel(cantrip_panel)

func _on_background_button_pressed() -> void:
	_show_panel(spell_panel)


func _on_spell_button_pressed() -> void:
	_show_panel(spell_panel)
# Function to handle the Race button press
func _on_race_button_pressed() -> void:
	_show_panel(race_panel)

# Function to handle the Class button press
func _on_class_button_pressed() -> void:
	_show_panel(class_panel)

# Function to handle the Sub-Class button press
func _on_sub_class_button_pressed() -> void:
	_show_panel(sub_class_panel)

# Function to show a specific panel and hide the rest
func _show_panel(panel_to_show: Panel) -> void:
	# Hide all panels
	for panel in all_panels:
		panel.visible = false

	# Show the selected panel
	panel_to_show.visible = true
