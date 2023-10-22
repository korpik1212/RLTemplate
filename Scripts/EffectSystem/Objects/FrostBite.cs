using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLTemplate
{
    [CreateAssetMenu(menuName = ("Effects/FrostBite"))]
    public class FrostBite : Effect
    {
        float tickCounter;
        public float triggerInterval;

        public override void Activate(CharacterData Target)
        {
            base.Activate(Target);
            target.characterStats.GetStatByID("attack_damage").AddModifier(new StatModifier(-15, ModifierType.Addition, this));
            target.characterStats.GetStatByID("attack_speed").AddModifier(new StatModifier(-15, ModifierType.Addition, this));
        }

        public override void Deactivate()
        {
            base.Deactivate();
            target.characterStats.RemoveAllModifiersBySource(this);
        }

        public override void Tick()
        {
            base.Tick();
            tickCounter += Time.fixedDeltaTime;
            if (tickCounter >= triggerInterval)
            {
                tickCounter = 0;
                FrostBiteEffect();
            }
        }


        private void FrostBiteEffect()
        {

        }
    }
}
