extends Node

@export var character: DnDCharacter

@onready var str_stat: LineEdit = %StrStat
@onready var str_mod: LineEdit = %StrMod
@onready var dex_stat: LineEdit = %DexStat
@onready var dex_mod: LineEdit = %DexMod
@onready var con_stat: LineEdit = %ConStat
@onready var con_mod: LineEdit = %ConMod
@onready var int_stat: LineEdit = %IntStat
@onready var int_mod: LineEdit = %IntMod
@onready var wis_stat: LineEdit = %WisStat
@onready var wis_mod: LineEdit = %WisMod
@onready var cha_stat: LineEdit = %ChaStat
@onready var cha_mod: LineEdit = %ChaMod

@onready var inspiration_val: LineEdit = %InspirationVal
@onready var proficiency_val: LineEdit = %ProficiencyVal

@onready var st_strength_bool: CheckBox = %STStrengthBool
@onready var st_strength_mod: LineEdit = %STStrengthMod
@onready var st_dexterity_bool: CheckBox = %STDexterityBool
@onready var st_dexterity_mod: LineEdit = %STDexterityMod
@onready var st_constitution_bool: CheckBox = %STConstitutionBool
@onready var st_constitution_mod: LineEdit = %STConstitutionMod
@onready var st_intelligence_bool: CheckBox = %STIntelligenceBool
@onready var st_intelligence_mod: LineEdit = %STIntelligenceMod
@onready var st_wisdom_bool: CheckBox = %STWisdomBool
@onready var st_wisdom_mod: LineEdit = %STWisdomMod
@onready var st_charisma_bool: CheckBox = %STCharismaBool
@onready var st_charisma_mod: LineEdit = %STCharismaMod

@onready var skill_acrobatics_bool: CheckBox = %SkillAcrobaticsBool
@onready var skill_acrobatics_mod: LineEdit = %SkillAcrobaticsMod
@onready var skill_animal_handling_bool: CheckBox = %SkillAnimalHandlingBool
@onready var skill_animal_handling_mod: LineEdit = %SkillAnimalHandlingMod
@onready var skill_arcana_bool: CheckBox = %SkillArcanaBool
@onready var skill_arcana_mod: LineEdit = %SkillArcanaMod
@onready var skill_athletics_bool: CheckBox = %SkillAthleticsBool
@onready var skill_athletics_mod: LineEdit = %SkillAthleticsMod
@onready var skill_deception_bool: CheckBox = %SkillDeceptionBool
@onready var skill_deception_mod: LineEdit = %SkillDeceptionMod
@onready var skill_history_bool: CheckBox = %SkillHistoryBool
@onready var skill_history_mod: LineEdit = %SkillHistoryMod
@onready var skill_insight_bool: CheckBox = %SkillInsightBool
@onready var skill_insight_mod: LineEdit = %SkillInsightMod
@onready var skill_intimidation_bool: CheckBox = %SkillIntimidationBool
@onready var skill_intimidation_mod: LineEdit = %SkillIntimidationMod
@onready var skill_investigation_bool: CheckBox = %SkillInvestigationBool
@onready var skill_investigation_mod: LineEdit = %SkillInvestigationMod
@onready var skill_medicine_bool: CheckBox = %SkillMedicineBool
@onready var skill_medicine_mod: LineEdit = %SkillMedicineMod
@onready var skill_nature_bool: CheckBox = %SkillNatureBool
@onready var skill_nature_mod: LineEdit = %SkillNatureMod
@onready var skill_perception_bool: CheckBox = %SkillPerceptionBool
@onready var skill_perception_mod: LineEdit = %SkillPerceptionMod
@onready var skill_performance_bool: CheckBox = %SkillPerformanceBool
@onready var skill_performance_mod: LineEdit = %SkillPerformanceMod
@onready var skill_persuasion_bool: CheckBox = %SkillPersuasionBool
@onready var skill_persuasion_mod: LineEdit = %SkillPersuasionMod
@onready var skill_religion_bool: CheckBox = %SkillReligionBool
@onready var skill_religion_mod: LineEdit = %SkillReligionMod
@onready var skill_sleight_of_hand_bool: CheckBox = %SkillSleightOfHandBool
@onready var skill_sleight_of_hand_mod: LineEdit = %SkillSleightOfHandMod
@onready var skill_stealth_bool: CheckBox = %SkillStealthBool
@onready var skill_stealth_mod: LineEdit = %SkillStealthMod
@onready var skill_survival_bool: CheckBox = %SkillSurvivalBool
@onready var skill_survival_mod: LineEdit = %SkillSurvivalMod

#@onready var stat_passive_wisdom: LineEdit = %StatPassiveWisdom

func _ready() -> void:
	# Populate Ability Scores and Computed Modifiers
	str_stat.text = str(character.Strength)
	str_mod.text = str(character.StrengthModifier)
	
	dex_stat.text = str(character.Dexterity)
	dex_mod.text = str(character.DexterityModifier)
	
	con_stat.text = str(character.Constitution)
	con_mod.text = str(character.ConstitutionModifier)
	
	int_stat.text = str(character.Intelligence)
	int_mod.text = str(character.IntelligenceModifier)
	
	wis_stat.text = str(character.Wisdom)
	wis_mod.text = str(character.WisdomModifier)
	
	cha_stat.text = str(character.Charisma)
	cha_mod.text = str(character.CharismaModifier)
	
	# Populate Inspiration and Proficiency
	inspiration_val.text = str(character.Inspiration)
	proficiency_val.text = str(character.ProficiencyBonus)
	
	# Populate Saving Throws
	var bonus = character.ProficiencyBonus if character.StrengthSaveProficient else 0
	st_strength_bool.button_pressed = character.StrengthSaveProficient
	st_strength_mod.text = str(character.StrengthModifier + bonus)
	
	bonus = character.ProficiencyBonus if character.DexteritySaveProficient else 0
	st_dexterity_bool.button_pressed = character.DexteritySaveProficient
	st_dexterity_mod.text = str(character.DexterityModifier + bonus)
	
	bonus = character.ProficiencyBonus if character.ConstitutionSaveProficient else 0
	st_constitution_bool.button_pressed = character.ConstitutionSaveProficient
	st_constitution_mod.text = str(character.ConstitutionModifier + bonus)
	
	bonus = character.ProficiencyBonus if character.IntelligenceSaveProficient else 0
	st_intelligence_bool.button_pressed = character.IntelligenceSaveProficient
	st_intelligence_mod.text = str(character.IntelligenceModifier + bonus)
	
	bonus = character.ProficiencyBonus if character.WisdomSaveProficient else 0
	st_wisdom_bool.button_pressed = character.WisdomSaveProficient
	st_wisdom_mod.text = str(character.WisdomModifier + bonus)
	
	bonus = character.ProficiencyBonus if character.CharismaSaveProficient else 0
	st_charisma_bool.button_pressed = character.CharismaSaveProficient
	st_charisma_mod.text = str(character.CharismaModifier + bonus)
	
	# Populate Skills (proficiency state and computed bonus)
	skill_acrobatics_bool.button_pressed = character.Acrobatics.IsProficient
	skill_acrobatics_mod.text = str(character.GetSkillBonus(character.Acrobatics))
	
	skill_animal_handling_bool.button_pressed = character.AnimalHandling.IsProficient
	skill_animal_handling_mod.text = str(character.GetSkillBonus(character.AnimalHandling))
	
	skill_arcana_bool.button_pressed = character.Arcana.IsProficient
	skill_arcana_mod.text = str(character.GetSkillBonus(character.Arcana))
	
	skill_athletics_bool.button_pressed = character.Athletics.IsProficient
	skill_athletics_mod.text = str(character.GetSkillBonus(character.Athletics))
	
	skill_deception_bool.button_pressed = character.Deception.IsProficient
	skill_deception_mod.text = str(character.GetSkillBonus(character.Deception))
	
	skill_history_bool.button_pressed = character.History.IsProficient
	skill_history_mod.text = str(character.GetSkillBonus(character.History))
	
	skill_insight_bool.button_pressed = character.Insight.IsProficient
	skill_insight_mod.text = str(character.GetSkillBonus(character.Insight))
	
	skill_intimidation_bool.button_pressed = character.Intimidation.IsProficient
	skill_intimidation_mod.text = str(character.GetSkillBonus(character.Intimidation))
	
	skill_investigation_bool.button_pressed = character.Investigation.IsProficient
	skill_investigation_mod.text = str(character.GetSkillBonus(character.Investigation))
	
	skill_medicine_bool.button_pressed = character.Medicine.IsProficient
	skill_medicine_mod.text = str(character.GetSkillBonus(character.Medicine))
	
	skill_nature_bool.button_pressed = character.Nature.IsProficient
	skill_nature_mod.text = str(character.GetSkillBonus(character.Nature))
	
	skill_perception_bool.button_pressed = character.Perception.IsProficient
	skill_perception_mod.text = str(character.GetSkillBonus(character.Perception))
	
	skill_performance_bool.button_pressed = character.Performance.IsProficient
	skill_performance_mod.text = str(character.GetSkillBonus(character.Performance))
	
	skill_persuasion_bool.button_pressed = character.Persuasion.IsProficient
	skill_persuasion_mod.text = str(character.GetSkillBonus(character.Persuasion))
	
	skill_religion_bool.button_pressed = character.Religion.IsProficient
	skill_religion_mod.text = str(character.GetSkillBonus(character.Religion))
	
	skill_sleight_of_hand_bool.button_pressed = character.SleightOfHand.IsProficient
	skill_sleight_of_hand_mod.text = str(character.GetSkillBonus(character.SleightOfHand))
	
	skill_stealth_bool.button_pressed = character.Stealth.IsProficient
	skill_stealth_mod.text = str(character.GetSkillBonus(character.Stealth))
	
	skill_survival_bool.button_pressed = character.Survival.IsProficient
	skill_survival_mod.text = str(character.GetSkillBonus(character.Survival))
	
	#Passive Wisdom
	#stat_passive_wisdom.text = str(10 + int(st_wisdom_mod.text))
