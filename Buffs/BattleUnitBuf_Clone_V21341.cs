namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_Clone_V21341 : BattleUnitBuf
    {
        public override bool IsControllable => _owner.faction == Faction.Enemy;

        public override int GetCardCostAdder(BattleDiceCardModel card)
        {
            return -99;
        }
    }
}