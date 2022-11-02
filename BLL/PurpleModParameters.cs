using System.Collections.Generic;
using BigDLL4221.BaseClass;
using BigDLL4221.Models;
using Purple_V21341.Buffs;

namespace Purple_V21341.BLL
{
    public class PurpleModParameters
    {
        public const string PackageId = "PurplePoisonV21341.Mod";
        public static string Path;
    }

    public static class MapModels
    {
        public static MapModel PurplePoisonMap =
            new MapModel(typeof(Wonderland_V21341MapManager), "PurplePoison_V21341", bgy: 0.25f);
    }

    public static class UnitModels
    {
        public static UnitModel NpcClone = new UnitModel(2, PurpleModParameters.PackageId, 2);

        public static UnitModel PlayerClone = new UnitModel(10000002, PurpleModParameters.PackageId, 2,
            summonedOnPlay: true, autoPlay: true);
    }

    public class SummonedUnitStatModels
    {
        public SummonedUnitStatModel CloneStatModel = new SummonedUnitStatModel(true, reviveAfterScenesNpc: 2,
            damageOptions:
            new DamageOptions(9999, lessMassAttackBreakDamage: 9999, lessMassAttackIndividualDamage: 9999,
                lessMassAttackIndividualBreakDamage: 9999));
    }

    public class NpcMechUtilModels
    {
        public NpcMechUtilBase PurplePoisonNpcUtil = new NpcMechUtilBase(new NpcMechUtilBaseModel(
            "PurpleBattleV21341",
            permanentBuffList: new List<BattleUnitBuf>
            {
                new BattleUnitBuf_SmokeBomb_V21341()
            },
            mechOptions: new Dictionary<int, MechPhaseOptions>
            {
                {
                    0, new MechPhaseOptions(mechHp: 412, extraDrawEachScene: 1, speedDieAdder: 2)
                },
                {
                    1,
                    new MechPhaseOptions(hasCustomMap: true, extraLightRecoverEachScene: 1, startMassAttack: true,
                        setCounterToMax: true,
                        changeCardCost: true, loweredCost: 2,
                        speedDieAdder: 4,
                        extraDrawEachScene: 2,
                        egoMassAttackCardsOptions: new List<SpecialAttackCardOptions>
                            { new SpecialAttackCardOptions(new LorId(PurpleModParameters.PackageId, 13)) },
                        buffOptions: new MechBuffOptions(
                            eachRoundStartBuffsNotAloneCountSupportChar: new List<BattleUnitBuf>
                                { new BattleUnitBuf_SmokeScreen_V21341() }), summonUnit: new List<UnitModel>
                        {
                            UnitModels.NpcClone
                        })
                }
            }));
    }

    public class MechUtilModels
    {
        public MechUtilBase PurplePoisonPlayerUtil = new MechUtilBase(new MechUtilBaseModel(
            new Dictionary<int, EgoOptions>
            {
                {
                    0, new EgoOptions(egoMaps: new Dictionary<LorId, MapModel>
                    {
                        {
                            new LorId(PurpleModParameters.PackageId, 12),
                            MapModels.PurplePoisonMap
                        }
                    })
                }
            },
            permanentBuffList: new List<BattleUnitBuf>
            {
                new BattleUnitBuf_SmokeBomb_V21341()
            }
            , personalCards: new Dictionary<LorId, PersonalCardOptions>
            {
                {
                    new LorId(PurpleModParameters.PackageId, 1),
                    new PersonalCardOptions(onPlayCard: true, expireAfterUse: true)
                },
                { new LorId(PurpleModParameters.PackageId, 2), new PersonalCardOptions(onPlayCard: true) },
                { new LorId(PurpleModParameters.PackageId, 3), new PersonalCardOptions(onPlayCard: true) },
                { new LorId(PurpleModParameters.PackageId, 4), new PersonalCardOptions(onPlayCard: true) },
                { new LorId(PurpleModParameters.PackageId, 11), new PersonalCardOptions(onPlayCard: true) },
                { new LorId(PurpleModParameters.PackageId, 12), new PersonalCardOptions() }
            }));
    }
}