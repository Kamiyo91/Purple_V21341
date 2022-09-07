using System.Linq;
using CustomMapUtility;
using Purple_V21341.Passives;

namespace Purple_V21341
{
    public class EnemyTeamStageManager_Wonderland_V21341 : EnemyTeamStageManager
    {
        private PassiveAbility_WonderlandNpc_V21341 _mainPassive;
        public override void OnWaveStart()
        {
            _mainPassive = BattleObjectManager.instance.GetAliveList(Faction.Enemy).FirstOrDefault()?.passiveDetail.PassiveList
                        .FirstOrDefault(x => x is PassiveAbility_WonderlandNpc_V21341) as PassiveAbility_WonderlandNpc_V21341;
            CustomMapHandler.InitCustomMap<Wonderland_V21341MapManager>("PurplePoison_V21341", 0.5f, 0.25f);
            if (_mainPassive == null || !_mainPassive.PhaseChanged) return;
            CustomMapHandler.EnforceMap();
            Singleton<StageController>.Instance.CheckMapChange();
        }

        public override void OnRoundStart()
        {
            if (_mainPassive == null || !_mainPassive.PhaseChanged) return;
            CustomMapHandler.EnforceMap();
        }
    }
}
