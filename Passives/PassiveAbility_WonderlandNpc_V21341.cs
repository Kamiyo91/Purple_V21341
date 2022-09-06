using System.Linq;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_WonderlandNpc_V21341 : PassiveAbilityBase
    {
        public bool PhaseChanged;
        public const int MechHp = 412;
        private BattleUnitBuf_SmokeBomb_V21341 _buff;
        private BattleUnitModel _additionalUnit;
        private int _count;
        public override void OnWaveStart()
        {
            _count = 0;
            PhaseChanged = owner.hp < MechHp;
            _buff = new BattleUnitBuf_SmokeBomb_V21341();
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_SmokeBomb_V21341>()) owner.bufListDetail.AddBuf(_buff);
        }

        public override int GetSpeedDiceAdder(int speedDiceResult)
        {
            if(!PhaseChanged) return base.GetSpeedDiceAdder(speedDiceResult);
            if (_additionalUnit == null || _additionalUnit.IsDead()) return 2;
            return base.GetSpeedDiceAdder(speedDiceResult);
        }

        public override void OnRoundStartAfter()
        {
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_SmokeBomb_V21341>())
            {
                _buff = new BattleUnitBuf_SmokeBomb_V21341();
                owner.bufListDetail.AddBuf(_buff);
            }
            _buff.OnAddBuf(1);
            if (!PhaseChanged) return;
            if (_additionalUnit == null || _additionalUnit.IsDead())
            {
                _count++;
                if (owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_SmokeScreenNpc_V21341) is
                    BattleUnitBuf_SmokeScreenNpc_V21341 buff)
                {
                    buff.DestoryAura();
                    owner.bufListDetail.RemoveBuf(buff);
                }
            }
            if (_count < 3) return;
            _count = 0;
            AddUnit();
            if(!owner.bufListDetail.HasBuf<BattleUnitBuf_SmokeScreenNpc_V21341>()) owner.bufListDetail.AddBuf(new BattleUnitBuf_SmokeScreenNpc_V21341());

        }

        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            MechHpCheck(dmg);
            return base.BeforeTakeDamage(attacker, dmg);
        }
        private void MechHpCheck(int dmg)
        {
            if (owner.hp - dmg > MechHp && !PhaseChanged) return;
            PhaseChanged = true;
            owner.SetHp(MechHp);
            owner.breakDetail.ResetGauge();
            owner.breakDetail.RecoverBreakLife(1, true);
            owner.breakDetail.nextTurnBreak = false;
            owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_KamiyoImmortalUntilRoundEnd());
        }
        private void AddUnit()
        {
            if (BattleObjectManager.instance.GetList(owner.faction).Exists(x => x == _additionalUnit))
                BattleObjectManager.instance.UnregisterUnit(_additionalUnit);
            _additionalUnit = UnitUtil.AddNewUnitEnemySide(new UnitModel
            {
                Id = 2,
                Name = ModParameters.NameTexts
                            .FirstOrDefault(x => x.Key.Equals(new LorId(PurpleModParameters.PackageId, 2))).Value,
                Pos = BattleObjectManager.instance.GetList(owner.faction).Count,
                EmotionLevel = owner.emotionDetail.EmotionLevel,
                OnWaveStart = true
            }, PurpleModParameters.PackageId);
            UnitUtil.RefreshCombatUI();
        }
    }
}
