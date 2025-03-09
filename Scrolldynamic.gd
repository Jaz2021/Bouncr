extends Control

@export var scroll_speed: float = 20.0
@export var min_y: float = -1000.0       # Upper limit (top)
@export var max_y: float = 0.0    # Lower limit (bottom)

func _input(event: InputEvent) -> void:
	if event is InputEventMouseButton:
		if event.button_index == MOUSE_BUTTON_WHEEL_UP:
			position.y = max(position.y - scroll_speed, min_y)
		elif event.button_index == MOUSE_BUTTON_WHEEL_DOWN:
			position.y = min(position.y + scroll_speed, max_y)
