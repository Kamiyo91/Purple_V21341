using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UI;

public class DiceCardSelfAbility_ShadowCard : DiceCardSelfAbilityBase
{
    public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
    {
        owner.personalEgoDetail.AddCard(self.GetID());
        UnitUtil.AddNewUnitPlayerSideCustomDataOnPlay("Gorman", 4, "TestName",BattleObjectManager.instance.GetAliveList(Faction.Player).Count);
        UnitUtil.RefreshCombatUI();
    }

    public static class UnitUtil
    {
        public static BattleUnitModel AddNewUnitPlayerSideCustomDataOnPlay(string packageId, int unitId, string unitName,
         int pos, XmlVector2 customPos = null, int emotionLevel = 0, int maxEmotionLevel = 5, bool autoPlay = false, Faction faction = Faction.Player)
        {
            var currentFloor = Singleton<StageController>.Instance.CurrentFloor;
            var unitData = new UnitDataModel(new LorId(packageId, unitId),
                faction == Faction.Player ? currentFloor : SephirahType.None);
            unitData.SetCustomName(unitName);
            var allyUnit = BattleObjectManager.CreateDefaultUnit(Faction.Player);
            allyUnit.index = pos;
            allyUnit.grade = unitData.grade;
            var aliveCount = BattleObjectManager.instance.GetAliveList(Faction.Player).Count;
            var positionList = Singleton<StageController>.Instance.GetStageModel().GetFloor(Singleton<StageController>.Instance.CurrentFloor).GetFormation().PostionList;
            if (positionList.Count <= 5 + aliveCount)
            {
                var info = new FormationPositionXmlData
                {
                    vector = new XmlVector2
                    {
                        x = 0,
                        y = 0
                    }
                };
                var position = new FormationPosition(info)
                {
                    eventList = new List<FormationPositionEvent>(),
                    index = 5 + aliveCount
                };
                positionList.Add(position);
            }
            allyUnit.formation = customPos != null
                ? new FormationPosition(new FormationPositionXmlData
                {
                    vector = customPos
                })
                : Singleton<StageController>.Instance.GetCurrentStageFloorModel().GetFormationPosition(allyUnit.index);
            var unitBattleData = new UnitBattleDataModel(Singleton<StageController>.Instance.GetStageModel(), unitData);
            unitBattleData.Init();
            allyUnit.SetUnitData(unitBattleData);
            allyUnit.OnCreated();
            allyUnit.speedDiceResult = new List<SpeedDice>();
            BattleObjectManager.instance.RegisterUnit(allyUnit);
            allyUnit.passiveDetail.OnUnitCreated();
            LevelUpEmotion(allyUnit, emotionLevel);
            allyUnit.emotionDetail.SetMaxEmotionLevel(maxEmotionLevel);
            allyUnit.allyCardDetail.DrawCards(allyUnit.UnitData.unitData.GetStartDraw());
            allyUnit.cardSlotDetail.RecoverPlayPoint(allyUnit.cardSlotDetail.GetMaxPlayPoint());
            allyUnit.OnWaveStart();
            allyUnit.OnRoundStart_speedDice();
            allyUnit.RollSpeedDice();
            if (autoPlay) SetAutoCardForPlayer(allyUnit);
            return allyUnit;
        }
        public static void LevelUpEmotion(BattleUnitModel owner, int value)
        {
            for (var i = 0; i < value; i++)
            {
                owner.emotionDetail.LevelUp_Forcely(1);
                owner.emotionDetail.CheckLevelUp();
            }

            StageController.Instance.GetCurrentStageFloorModel().team.UpdateCoin();
        }
        public static void RefreshCombatUI(bool forceReturn = false, bool returnEffect = false)
        {
            foreach (var (battleUnit, num) in BattleObjectManager.instance.GetList()
                         .Select((value, i) => (value, i)))
            {
                SingletonBehavior<UICharacterRenderer>.Instance.SetCharacter(battleUnit.UnitData.unitData, num,
                    true);
                if (forceReturn)
                    battleUnit.moveDetail.ReturnToFormationByBlink(returnEffect);
            }

            try
            {
                BattleObjectManager.instance.InitUI();
            }
            catch (IndexOutOfRangeException)
            {
                // ignored
            }
        }
        public static void SetAutoCardForPlayer(BattleUnitModel unit)
        {
            for (var j = 0; j < unit.speedDiceResult.Count; j++)
            {
                if (unit.speedDiceResult[j].breaked || unit.cardSlotDetail.cardAry[j] != null) continue;
                unit.cardOrder = j;
                unit.allyCardDetail.PlayTurnAutoForPlayer(j);
            }

            var selectedAllyDice = SingletonBehavior<BattleManagerUI>.Instance.selectedAllyDice;
            SingletonBehavior<BattleManagerUI>.Instance.ui_TargetArrow.UpdateTargetList();
            SingletonBehavior<BattleManagerUI>.Instance.ui_emotionInfoBar.UpdateCardsStateUI();
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitInformationPlayer.ReleaseSelectedCard();
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitInformationPlayer.CloseUnitInformation(true);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitCardsInHand.OnPointerOverInSpeedDice = null;
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitCardsInHand.SetToDefault();
            if (selectedAllyDice != null) BattleUIInputController.Instance.ResetCharacterCursor(false);
        }
    }
}