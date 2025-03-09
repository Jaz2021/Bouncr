extends Control

@export var character: DnDCharacter

@onready var character_name_val: LineEdit = %CharacterNameVal
@onready var class_and_level_val: LineEdit = %ClassAndLevelVal
@onready var race_val: LineEdit = %RaceVal
@onready var background_val: LineEdit = %BackgroundVal
@onready var alignment_val: LineEdit = %AlignmentVal
@onready var player_name_val: LineEdit = %PlayerNameVal
@onready var experience_points_val: LineEdit = %ExperiencePointsVal

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
@onready var passive_wisdom_val: LineEdit = %PassiveWisdomVal
@onready var proficiencies_val: TextEdit = %ProficienciesVal

@onready var copper_val: LineEdit = %CopperVal
@onready var silver_val: LineEdit = %SilverVal
@onready var electrum_val: LineEdit = %ElectrumVal
@onready var gold_val_2: LineEdit = %GoldVal2
@onready var platinum_val_2: LineEdit = %PlatinumVal2

@onready var equipment_val: TextEdit = %EquipmentVal
@onready var personality_traits_val: TextEdit = %PersonalityTraitsVal
@onready var ideals_val: TextEdit = %IdealsVal
@onready var bonds_val: TextEdit = %BondsVal
@onready var flaws_val: TextEdit = %FlawsVal
@onready var features_and_traits_val: TextEdit = %FeaturesAndTraitsVal
