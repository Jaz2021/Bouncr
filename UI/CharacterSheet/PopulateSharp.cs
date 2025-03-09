using Godot;
using System;

public partial class PopulateSharp : Control
{
    // Exported property so you can assign it from the editor.
    [Export]
    public DnDCharacter character;

    // UI node fields (set in _Ready)
    private LineEdit characterNameVal;
    private LineEdit classAndLevelVal;
    private LineEdit raceVal;
    private LineEdit backgroundVal;
    private LineEdit alignmentVal;
    private LineEdit playerNameVal;
    private LineEdit experiencePointsVal;
    private LineEdit strStat;
    private LineEdit strMod;
    private LineEdit dexStat;
    private LineEdit dexMod;
    private LineEdit conStat;
    private LineEdit conMod;
    private LineEdit intStat;
    private LineEdit intMod;
    private LineEdit wisStat;
    private LineEdit wisMod;
    private LineEdit chaStat;
    private LineEdit chaMod;
    private LineEdit inspirationVal;
    private LineEdit proficiencyVal;

    private CheckBox stStrengthBool;
    private LineEdit stStrengthMod;
    private CheckBox stDexterityBool;
    private LineEdit stDexterityMod;
    private CheckBox stConstitutionBool;
    private LineEdit stConstitutionMod;
    private CheckBox stIntelligenceBool;
    private LineEdit stIntelligenceMod;
    private CheckBox stWisdomBool;
    private LineEdit stWisdomMod;
    private CheckBox stCharismaBool;
    private LineEdit stCharismaMod;

    private CheckBox skillAcrobaticsBool;
    private LineEdit skillAcrobaticsMod;
    private CheckBox skillAnimalHandlingBool;
    private LineEdit skillAnimalHandlingMod;
    private CheckBox skillArcanaBool;
    private LineEdit skillArcanaMod;
    private CheckBox skillAthleticsBool;
    private LineEdit skillAthleticsMod;
    private CheckBox skillDeceptionBool;
    private LineEdit skillDeceptionMod;
    private CheckBox skillHistoryBool;
    private LineEdit skillHistoryMod;
    private CheckBox skillInsightBool;
    private LineEdit skillInsightMod;
    private CheckBox skillIntimidationBool;
    private LineEdit skillIntimidationMod;
    private CheckBox skillInvestigationBool;
    private LineEdit skillInvestigationMod;
    private CheckBox skillMedicineBool;
    private LineEdit skillMedicineMod;
    private CheckBox skillNatureBool;
    private LineEdit skillNatureMod;
    private CheckBox skillPerceptionBool;
    private LineEdit skillPerceptionMod;
    private CheckBox skillPerformanceBool;
    private LineEdit skillPerformanceMod;
    private CheckBox skillPersuasionBool;
    private LineEdit skillPersuasionMod;
    private CheckBox skillReligionBool;
    private LineEdit skillReligionMod;
    private CheckBox skillSleightOfHandBool;
    private LineEdit skillSleightOfHandMod;
    private CheckBox skillStealthBool;
    private LineEdit skillStealthMod;
    private CheckBox skillSurvivalBool;
    private LineEdit skillSurvivalMod;

    private LineEdit armorClassVal;
    private LineEdit initiativeVal;
    private LineEdit speedVal;
    private LineEdit hitPointMaximumVal;
    private LineEdit currentHitPointsVal;
    private LineEdit tempHitPointsVal;
    private LineEdit totalHitVal;
    private LineEdit hitDiceVal;

    private CheckBox deathSave1Val;
    private CheckBox deathSave2Val;
    private CheckBox deathSave3Val;
    private CheckBox deathFail1Val;
    private CheckBox deathFail2Val;
    private CheckBox deathFail3Val;

    private LineEdit weaponName1;
    private LineEdit weaponName2;
    private LineEdit weaponName3;
    private LineEdit weaponAtkBonus1;
    private LineEdit weaponAtkBonus2;
    private LineEdit weaponAtkBonus3;
    private LineEdit weaponDamageType1;
    private LineEdit weaponDamageType2;
    private LineEdit weaponDamageType3;

    private TextEdit weaponInfoVal;
    private LineEdit passiveWisdomVal;
    private TextEdit proficienciesVal;

    private LineEdit copperVal;
    private LineEdit silverVal;
    private LineEdit electrumVal;
    private LineEdit goldVal2;
    private LineEdit platinumVal2;

    private TextEdit equipmentVal;
    private TextEdit personalityTraitsVal;
    private TextEdit idealsVal;
    private TextEdit bondsVal;
    private TextEdit flawsVal;
    private TextEdit featuresAndTraitsVal;

    public override void _Ready()
    {
        character = Global.instance.character;

        // Get node references (make sure the paths match your scene tree)
        characterNameVal = GetNode<LineEdit>("VBoxContainer/Title/PanelContainer/HBoxContainer/CharacterName/VBoxContainer/CharacterNameVal");
        classAndLevelVal = GetNode<LineEdit>("VBoxContainer/Title/PanelContainer/HBoxContainer/VBoxContainer/ClassLevel/VBoxContainer/ClassAndLevelVal");
        raceVal = GetNode<LineEdit>("VBoxContainer/Title/PanelContainer/HBoxContainer/VBoxContainer/Race/VBoxContainer/RaceVal");
        backgroundVal = GetNode<LineEdit>("VBoxContainer/Title/PanelContainer/HBoxContainer/VBoxContainer2/Background/VBoxContainer/BackgroundVal");
        alignmentVal = GetNode<LineEdit>("VBoxContainer/Title/PanelContainer/HBoxContainer/VBoxContainer2/Alignment/VBoxContainer/AlignmentVal");
        playerNameVal = GetNode<LineEdit>("VBoxContainer/Title/PanelContainer/HBoxContainer/VBoxContainer3/PlayerName/VBoxContainer/PlayerNameVal");
        experiencePointsVal = GetNode<LineEdit>("VBoxContainer/Title/PanelContainer/HBoxContainer/VBoxContainer3/ExperiencePoints/VBoxContainer/ExperiencePointsVal");
        strStat = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBStr/StrStat");
        strMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBStr/StrMod");
        dexStat = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBDex/DexStat");
        dexMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBDex/DexMod");
        conStat = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBCon/ConStat");
        conMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBCon/ConMod");
        intStat = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBInt/IntStat");
        intMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBInt/IntMod");
        wisStat = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBWis/WisStat");
        wisMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBWis/WisMod");
        chaStat = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBCha/ChaStat");
        chaMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/Stats/VBStats/VBCha/ChaMod");
        inspirationVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Inspiration/VBInspiration/HBInspiration/InspirationVal");
        proficiencyVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/ProficiencyBonus/VBProficiencyBonus/HBProficiencyBonus/ProficiencyVal");

        stStrengthBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBStrength/STStrengthBool");
        stStrengthMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBStrength/STStrengthMod");
        stDexterityBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBDexterity/STDexterityBool");
        stDexterityMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBDexterity/STDexterityMod");
        stConstitutionBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBConstitution/STConstitutionBool");
        stConstitutionMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBConstitution/STConstitutionMod");
        stIntelligenceBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBIntelligence/STIntelligenceBool");
        stIntelligenceMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBIntelligence/STIntelligenceMod");
        stWisdomBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBWisdom/STWisdomBool");
        stWisdomMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBWisdom/STWisdomMod");
        stCharismaBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBCharisma/STCharismaBool");
        stCharismaMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/SavingThrows/VBSavingThrows/HBCharisma/STCharismaMod");

        skillAcrobaticsBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBAcrobatics/SkillAcrobaticsBool");
        skillAcrobaticsMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBAcrobatics/SkillAcrobaticsMod");
        skillAnimalHandlingBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBAnimalHandling/SkillAnimalHandlingBool");
        skillAnimalHandlingMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBAnimalHandling/SkillAnimalHandlingMod");
        skillArcanaBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBArcana/SkillArcanaBool");
        skillArcanaMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBArcana/SkillArcanaMod");
        skillAthleticsBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBAthletics/SkillAthleticsBool");
        skillAthleticsMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBAthletics/SkillAthleticsMod");
        skillDeceptionBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBDeception/SkillDeceptionBool");
        skillDeceptionMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBDeception/SkillDeceptionMod");
        skillHistoryBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBHistory/SkillHistoryBool");
        skillHistoryMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBHistory/SkillHistoryMod");
        skillInsightBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBInsight/SkillInsightBool");
        skillInsightMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBInsight/SkillInsightMod");
        skillIntimidationBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBIntimidation/SkillIntimidationBool");
        skillIntimidationMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBIntimidation/SkillIntimidationMod");
        skillInvestigationBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBInvestigation/SkillInvestigationBool");
        skillInvestigationMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBInvestigation/SkillInvestigationMod");
        skillMedicineBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBMedicine/SkillMedicineBool");
        skillMedicineMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBMedicine/SkillMedicineMod");
        skillNatureBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBNature/SkillNatureBool");
        skillNatureMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBNature/SkillNatureMod");
        skillPerceptionBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBPerception/SkillPerceptionBool");
        skillPerceptionMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBPerception/SkillPerceptionMod");
        skillPerformanceBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBPerformance/SkillPerformanceBool");
        skillPerformanceMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBPerformance/SkillPerformanceMod");
        skillPersuasionBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBPersuasion/SkillPersuasionBool");
        skillPersuasionMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBPersuasion/SkillPersuasionMod");
        skillReligionBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBReligion/SkillReligionBool");
        skillReligionMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBReligion/SkillReligionMod");
        skillSleightOfHandBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBSleightOfHand/SkillSleightOfHandBool");
        skillSleightOfHandMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBSleightOfHand/SkillSleightOfHandMod");
        skillStealthBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBStealth/SkillStealthBool");
        skillStealthMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBStealth/SkillStealthMod");
        skillSurvivalBool = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBSurvival/SkillSurvivalBool");
        skillSurvivalMod = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/Stats/HBoxContainer/VBStatBlock/HBoxContainer/VBoxContainer2/Skills/VBSkills/HBSurvival/SkillSurvivalMod");

        armorClassVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/ACIniativeSpeed/VBoxContainer/HBoxContainer/ArmorClass/VBoxContainer/ArmorClassVal");
        initiativeVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/ACIniativeSpeed/VBoxContainer/HBoxContainer/Initiative/VBoxContainer/InitiativeVal");
        speedVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/ACIniativeSpeed/VBoxContainer/HBoxContainer/Speed/VBoxContainer/SpeedVal");
        hitPointMaximumVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitPoints/VBoxContainer/HBoxContainer/HitPointMaximumVal");
        currentHitPointsVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitPoints/VBoxContainer/CurrentHitPointsVal");
        tempHitPointsVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/TempHitPoints/VBoxContainer/TempHitPointsVal");
        totalHitVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/HitDice/VBoxContainer/HBoxContainer/TotalHitVal");
        hitDiceVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/HitDice/VBoxContainer/HitDiceVal");

        deathSave1Val = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/DeathSaves/VBoxContainer/HBoxContainer/DeathSave1Val");
        deathSave2Val = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/DeathSaves/VBoxContainer/HBoxContainer/DeathSave2Val");
        deathSave3Val = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/DeathSaves/VBoxContainer/HBoxContainer/DeathSave3Val");
        deathFail1Val = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/DeathSaves/VBoxContainer/HBoxContainer2/DeathFail1Val");
        deathFail2Val = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/DeathSaves/VBoxContainer/HBoxContainer2/DeathFail2Val");
        deathFail3Val = GetNode<CheckBox>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/HitDiceDeathSave/HBoxContainer/DeathSaves/VBoxContainer/HBoxContainer2/DeathFail3Val");

        weaponName1 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBName/WeaponName1");
        weaponName2 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBName/WeaponName2");
        weaponName3 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBName/WeaponName3");
        weaponAtkBonus1 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBATKBonus/WeaponAtkBonus1");
        weaponAtkBonus2 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBATKBonus/WeaponAtkBonus2");
        weaponAtkBonus3 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBATKBonus/WeaponAtkBonus3");
        weaponDamageType1 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBDamageType/WeaponDamageType1");
        weaponDamageType2 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBDamageType/WeaponDamageType2");
        weaponDamageType3 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/HBoxContainer/VBDamageType/WeaponDamageType3");

        weaponInfoVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer/PanelContainer/VBoxContainer/AttacksAndSpellcasting/VBoxContainer/WeaponInfoVal");
        passiveWisdomVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/VBoxContainer/Passive Wisdom/HBoxContainer/PassiveWisdomVal");
        proficienciesVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/VBoxContainer/Proficiencies/VBoxContainer/ProficienciesVal");

        copperVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/Equipment/VBoxContainer/HBoxContainer/VBoxContainer/Copper/HBoxContainer/CopperVal");
        silverVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/Equipment/VBoxContainer/HBoxContainer/VBoxContainer/Silver/HBoxContainer/SilverVal");
        electrumVal = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/Equipment/VBoxContainer/HBoxContainer/VBoxContainer/Electrum/HBoxContainer/ElectrumVal");
        goldVal2 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/Equipment/VBoxContainer/HBoxContainer/VBoxContainer/Gold/HBoxContainer/GoldVal2");
        platinumVal2 = GetNode<LineEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/Equipment/VBoxContainer/HBoxContainer/VBoxContainer/Platinum/HBoxContainer/PlatinumVal2");

        equipmentVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/VBoxContainer/HBoxContainer2/Equipment/VBoxContainer/HBoxContainer/EquipmentVal");
        personalityTraitsVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/Traits/VBoxContainer/PersonalityTraits/VBoxContainer/PersonalityTraitsVal");
        idealsVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/Traits/VBoxContainer/Ideals/VBoxContainer/IdealsVal");
        bondsVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/Traits/VBoxContainer/Bonds/VBoxContainer/BondsVal");
        flawsVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/Traits/VBoxContainer/Flaws/VBoxContainer/FlawsVal");
        featuresAndTraitsVal = GetNode<TextEdit>("VBoxContainer/PanelContainer2/HBoxContainer/Traits/VBoxContainer/FeaturesAndTraits/VBoxContainer/FeaturesAndTraitsVal");

        // Check if the character resource is set
        if (character != null)
        {
            GD.Print("PAST NULL");
            // -- Basic Character Information --
            characterNameVal.Text = character.CharacterName;
            classAndLevelVal.Text = $"{character.Class} Level {character.Level}";
            raceVal.Text = character.Race;
            backgroundVal.Text = character.Background;
            alignmentVal.Text = character.Alignment.ToString();
            playerNameVal.Text = character.PlayerName;
            experiencePointsVal.Text = character.ExperiencePoints.ToString();

            // -- Ability Scores & Modifiers --
            strStat.Text = character.Strength.ToString();
            strMod.Text = character.StrengthModifier.ToString();
            dexStat.Text = character.Dexterity.ToString();
            dexMod.Text = character.DexterityModifier.ToString();
            conStat.Text = character.Constitution.ToString();
            conMod.Text = character.ConstitutionModifier.ToString();
            intStat.Text = character.Intelligence.ToString();
            intMod.Text = character.IntelligenceModifier.ToString();
            wisStat.Text = character.Wisdom.ToString();
            wisMod.Text = character.WisdomModifier.ToString();
            chaStat.Text = character.Charisma.ToString();
            chaMod.Text = character.CharismaModifier.ToString();
            inspirationVal.Text = character.Inspiration.ToString();
            proficiencyVal.Text = character.ProficiencyBonus.ToString();

            // -- Saving Throws --
            stStrengthBool.ButtonPressed = character.StrengthSaveProficient;
            stStrengthMod.Text = (character.StrengthModifier + (character.StrengthSaveProficient ? character.ProficiencyBonus : 0)).ToString();

            stDexterityBool.ButtonPressed = character.DexteritySaveProficient;
            stDexterityMod.Text = (character.DexterityModifier + (character.DexteritySaveProficient ? character.ProficiencyBonus : 0)).ToString();

            stConstitutionBool.ButtonPressed = character.ConstitutionSaveProficient;
            stConstitutionMod.Text = (character.ConstitutionModifier + (character.ConstitutionSaveProficient ? character.ProficiencyBonus : 0)).ToString();

            stIntelligenceBool.ButtonPressed = character.IntelligenceSaveProficient;
            stIntelligenceMod.Text = (character.IntelligenceModifier + (character.IntelligenceSaveProficient ? character.ProficiencyBonus : 0)).ToString();

            stWisdomBool.ButtonPressed = character.WisdomSaveProficient;
            stWisdomMod.Text = (character.WisdomModifier + (character.WisdomSaveProficient ? character.ProficiencyBonus : 0)).ToString();

            stCharismaBool.ButtonPressed = character.CharismaSaveProficient;
            stCharismaMod.Text = (character.CharismaModifier + (character.CharismaSaveProficient ? character.ProficiencyBonus : 0)).ToString();

            // -- Skills --
            skillAcrobaticsBool.ButtonPressed = character.Acrobatics.IsProficient;
            skillAcrobaticsMod.Text = character.GetSkillBonus(character.Acrobatics).ToString();

            skillAnimalHandlingBool.ButtonPressed = character.AnimalHandling.IsProficient;
            skillAnimalHandlingMod.Text = character.GetSkillBonus(character.AnimalHandling).ToString();

            skillArcanaBool.ButtonPressed = character.Arcana.IsProficient;
            skillArcanaMod.Text = character.GetSkillBonus(character.Arcana).ToString();

            skillAthleticsBool.ButtonPressed = character.Athletics.IsProficient;
            skillAthleticsMod.Text = character.GetSkillBonus(character.Athletics).ToString();

            skillDeceptionBool.ButtonPressed = character.Deception.IsProficient;
            skillDeceptionMod.Text = character.GetSkillBonus(character.Deception).ToString();

            skillHistoryBool.ButtonPressed = character.History.IsProficient;
            skillHistoryMod.Text = character.GetSkillBonus(character.History).ToString();

            skillInsightBool.ButtonPressed = character.Insight.IsProficient;
            skillInsightMod.Text = character.GetSkillBonus(character.Insight).ToString();

            skillIntimidationBool.ButtonPressed = character.Intimidation.IsProficient;
            skillIntimidationMod.Text = character.GetSkillBonus(character.Intimidation).ToString();

            skillInvestigationBool.ButtonPressed = character.Investigation.IsProficient;
            skillInvestigationMod.Text = character.GetSkillBonus(character.Investigation).ToString();

            skillMedicineBool.ButtonPressed = character.Medicine.IsProficient;
            skillMedicineMod.Text = character.GetSkillBonus(character.Medicine).ToString();

            skillNatureBool.ButtonPressed = character.Nature.IsProficient;
            skillNatureMod.Text = character.GetSkillBonus(character.Nature).ToString();

            skillPerceptionBool.ButtonPressed = character.Perception.IsProficient;
            skillPerceptionMod.Text = character.GetSkillBonus(character.Perception).ToString();

            skillPerformanceBool.ButtonPressed = character.Performance.IsProficient;
            skillPerformanceMod.Text = character.GetSkillBonus(character.Performance).ToString();

            skillPersuasionBool.ButtonPressed = character.Persuasion.IsProficient;
            skillPersuasionMod.Text = character.GetSkillBonus(character.Persuasion).ToString();

            skillReligionBool.ButtonPressed = character.Religion.IsProficient;
            skillReligionMod.Text = character.GetSkillBonus(character.Religion).ToString();

            skillSleightOfHandBool.ButtonPressed = character.SleightOfHand.IsProficient;
            skillSleightOfHandMod.Text = character.GetSkillBonus(character.SleightOfHand).ToString();

            skillStealthBool.ButtonPressed = character.Stealth.IsProficient;
            skillStealthMod.Text = character.GetSkillBonus(character.Stealth).ToString();

            skillSurvivalBool.ButtonPressed = character.Survival.IsProficient;
            skillSurvivalMod.Text = character.GetSkillBonus(character.Survival).ToString();

            // -- Combat Stats --
            armorClassVal.Text = character.ArmorClass.ToString();
            initiativeVal.Text = character.Initiative.ToString();
            speedVal.Text = character.Speed.ToString();
            hitPointMaximumVal.Text = character.HitPointMaximum.ToString();
            currentHitPointsVal.Text = character.CurrentHitPoints.ToString();
            tempHitPointsVal.Text = character.TemporaryHitPoints.ToString();
            totalHitVal.Text = character.HitDiceTotal.ToString();
            hitDiceVal.Text = character.HitDice.ToString();

            // -- Death Saves --
            deathSave1Val.ButtonPressed = character.DeathSaveSuccess >= 1;
            deathSave2Val.ButtonPressed = character.DeathSaveSuccess >= 2;
            deathSave3Val.ButtonPressed = character.DeathSaveSuccess >= 3;

            deathFail1Val.ButtonPressed = character.DeathSaveFailier >= 1;
            deathFail2Val.ButtonPressed = character.DeathSaveFailier >= 2;
            deathFail3Val.ButtonPressed = character.DeathSaveFailier >= 3;

            // -- Weapons & Other Placeholders --
            weaponInfoVal.Text = "Weapon details not implemented";
            passiveWisdomVal.Text = "Not implemented";
            proficienciesVal.Text = "Proficiencies details not implemented";

            copperVal.Text = "0";
            silverVal.Text = "0";
            electrumVal.Text = "0";
            goldVal2.Text = "0";
            platinumVal2.Text = "0";

            equipmentVal.Text = "Equipment details not implemented";
            personalityTraitsVal.Text = "Personality traits not implemented";
            idealsVal.Text = "Ideals not implemented";
            bondsVal.Text = "Bonds not implemented";
            flawsVal.Text = "Flaws not implemented";
            featuresAndTraitsVal.Text = "Features and traits not implemented";
        }
        else
        {
            GD.PushWarning("Character resource not set!");
        }
    }
}
