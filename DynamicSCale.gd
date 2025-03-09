extends Control

var base_resolution = Vector2()

func _ready():
	# If no base resolution is defined (i.e. it's (0,0)), use the current viewport size.
	if base_resolution == Vector2():
		base_resolution = get_viewport_rect().size
	update_scale()

func _notification(what):
	if what == NOTIFICATION_RESIZED:
		update_scale()

func update_scale():
	var current_size = get_viewport_rect().size
	# Calculate the scaling factors for width and height.
	var width_scale = current_size.x / base_resolution.x
	#var height_scale = current_size.y / base_resolution.y
	# Use the smaller scale factor so the UI always fits within the viewport.
	var scale_factor = width_scale#min(width_scale, height_scale)
	self.scale = Vector2(scale_factor, scale_factor)
