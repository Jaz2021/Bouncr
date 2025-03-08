extends CenterContainer

@export var character: DnDCharacter

@onready var character_name_val: LineEdit = %CharacterNameVal
@onready var class_and_level_val: LineEdit = %ClassAndLevelVal
@onready var race_val: LineEdit = %RaceVal
@onready var background_val: LineEdit = %BackgroundVal
@onready var alignment_val: LineEdit = %AlignmentVal
@onready var player_name_val: LineEdit = %PlayerNameVal
@onready var experience_points_val: LineEdit = %ExperiencePointsVal

func alignment_to_text(alignment) -> String:
	match alignment:
		0:
			return "Lawful Good"
		1:
			return "Neutral Good"
		2:
			return "Chaotic Good"
		3:
			return "Lawful Neutral"
		4:
			return "True Neutral"
		5:
			return "Chaotic Neutral"
		6:
			return "Lawful Evil"
		7:
			return "Neutral Evil"
		8:
			return "Chaotic Evil"
		_:
			return "Unknown"

func _ready() -> void:
	if character:
		character_name_val.text = character.CharacterName
		class_and_level_val.text = str(character.Level) + " " + character.Class
		race_val.text = character.Race
		background_val.text = character.Background
		alignment_val.text = alignment_to_text(character.Alignment)
		player_name_val.text = character.PlayerName
		experience_points_val.text = str(character.ExperiencePoints)
	else:
		push_error("No character resource assigned to 'character'.")
