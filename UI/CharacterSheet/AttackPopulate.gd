extends CenterContainer

# Export the DnDCharacter resource so it can be assigned in the inspector.
@export var dnd_character: DnDCharacter

@onready var armor_class_val: LineEdit = %ArmorClassVal
@onready var initiative_val: LineEdit = %InitiativeVal
@onready var speed_val: LineEdit = %SpeedVal
@onready var hit_point_maximum_val: LineEdit = %HitPointMaximumVal
@onready var current_hit_points_val: LineEdit = %CurrentHitPointsVal
@onready var temp_hit_points_val: LineEdit = %TempHitPointsVal
@onready var total_hit_val: LineEdit = %TotalHitVal
@onready var hit_dice_val: LineEdit = %HitDiceVal
@onready var death_save_1_val: CheckBox = %DeathSave1Val
@onready var death_save_2_val: CheckBox = %DeathSave2Val
@onready var death_save_3_val: CheckBox = %DeathSave3Val
@onready var death_fail_1_val: CheckBox = %DeathFail1Val
@onready var death_fail_2_val: CheckBox = %DeathFail2Val
@onready var death_fail_3_val: CheckBox = %DeathFail3Val
@onready var weapon_name_1: LineEdit = %WeaponName1
@onready var weapon_name_2: LineEdit = %WeaponName2
@onready var weapon_name_3: LineEdit = %WeaponName3
@onready var weapon_atk_bonus_1: LineEdit = %WeaponAtkBonus1
@onready var weapon_atk_bonus_2: LineEdit = %WeaponAtkBonus2
@onready var weapon_atk_bonus_3: LineEdit = %WeaponAtkBonus3
@onready var weapon_damage_type_1: LineEdit = %WeaponDamageType1
@onready var weapon_damage_type_2: LineEdit = %WeaponDamageType2
@onready var weapon_damage_type_3: LineEdit = %WeaponDamageType3
@onready var weapon_info_val: TextEdit = %WeaponInfoVal

func _ready() -> void:
	update_ui_from_character()

func update_ui_from_character() -> void:
	if not dnd_character:
		print("No DnDCharacter resource assigned!")
		return

	# Update combat stats.
	armor_class_val.text = str(dnd_character.ArmorClass)
	initiative_val.text = str(dnd_character.Initiative)
	speed_val.text = str(dnd_character.Speed)
	hit_point_maximum_val.text = str(dnd_character.HitPointMaximum)
	current_hit_points_val.text = str(dnd_character.CurrentHitPoints)
	temp_hit_points_val.text = str(dnd_character.TemporaryHitPoints)
	total_hit_val.text = str(dnd_character.HitDiceTotal)
	var dice_names = {
		0: "d2",
		1: "d4",
		2: "d6",
		3: "d8",
		4: "d10",
		5: "d12",
		6: "d20"
	}
	hit_dice_val.text = dice_names[dnd_character.HitDice]


	# Update death save checkboxes.
	death_save_1_val.button_pressed = dnd_character.DeathSaveSuccess >= 1
	death_save_2_val.button_pressed = dnd_character.DeathSaveSuccess >= 2
	death_save_3_val.button_pressed = dnd_character.DeathSaveSuccess >= 3

	death_fail_1_val.button_pressed = dnd_character.DeathSaveFailier >= 1
	death_fail_2_val.button_pressed = dnd_character.DeathSaveFailier >= 2
	death_fail_3_val.button_pressed = dnd_character.DeathSaveFailier >= 3

	# Weapon fields – as placeholders since DnDCharacter doesn't include weapon data.
	weapon_name_1.text = ""
	weapon_name_2.text = ""
	weapon_name_3.text = ""
	weapon_atk_bonus_1.text = "0"
	weapon_atk_bonus_2.text = "0"
	weapon_atk_bonus_3.text = "0"
	weapon_damage_type_1.text = ""
	weapon_damage_type_2.text = ""
	weapon_damage_type_3.text = ""
	weapon_info_val.text = ""
