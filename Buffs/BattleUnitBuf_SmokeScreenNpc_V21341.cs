using UnityEngine;

namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_SmokeScreenNpc_V21341 : BattleUnitBuf
    {
        private GameObject _aura;
        public override bool IsTargetable()
        {
            return false;
        }
        public override bool DirectAttack()
        {
            return true;
        }

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            CreateSmokeScreen();
        }

        public void DestoryAura()
        {
            if (_aura == null) return;
            Object.Destroy(_aura.gameObject);
            _aura = null;
        }
        public void CreateSmokeScreen()
        {
            var original = Resources.Load("Prefabs/Battle/DiceAttackEffects/new/fx/mon/elilin/FX_Mon_Elilin2_Aura");
            if (original == null) return;
            _aura = Object.Instantiate(original) as GameObject;
            if (_aura == null) return;
            _aura.transform.parent = _owner.view.charAppearance.transform;
            _aura.transform.localPosition = Vector3.zero;
            _aura.transform.localRotation = Quaternion.identity;
            _aura.transform.localScale = Vector3.one;
            var particleSystems = _aura.gameObject.GetComponentsInChildren<ParticleSystem>();
            foreach (var particleSystem in particleSystems)
                if (particleSystem.gameObject.name.Equals("Smoke")) particleSystem.gameObject.SetActive(false);
        }
    }
}
