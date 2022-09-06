namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_Clone_V21341 : BattleUnitBuf
    {
        public override bool IsControllable => false;
        public override void OnRoundEndTheLast()
        {
            _owner.Die();
            BattleObjectManager.instance.UnregisterUnit(_owner);
        }

        public override int GetCardCostAdder(BattleDiceCardModel card)
        {
            return -99;
        }
    }
}
