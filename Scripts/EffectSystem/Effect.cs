using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLTemplate
{
    public class Effect : ScriptableObject
    {
        public string effectName;
        public string effectId;
        public string effectDescription;
        public Sprite effectSprite;
        public float effectDuaration;

        protected CharacterData target;

        protected int stackAmount = 1;
        protected float remainingDuration;
        public EffectBehaviour effectBehaviour;
        public StackBehavior stackBehavior;
        public EffectType effectType;

        public virtual void Activate(CharacterData owner)
        {
            this.target = owner;
            switch (effectBehaviour)
            {
                case EffectBehaviour.instant: break;
                case EffectBehaviour.infinite: break;
                case EffectBehaviour.durational: remainingDuration = effectDuaration; break;
            }
        }

        public virtual void Deactivate()
        {
            target.effectManager.RemoveEffect(this);
        }

        public virtual void Tick()
        {
            remainingDuration -= Time.fixedDeltaTime;
            if (remainingDuration <= 0)
            {
                Deactivate();
            }
        }

        public virtual void Stack(Effect effect)
        {
            switch (stackBehavior)
            {
                case StackBehavior.resetting:
                    if (effect.effectDuaration > remainingDuration) remainingDuration = effect.effectDuaration;
                    break;
                case StackBehavior.stackable:
                    stackAmount++;
                    if (effect.effectDuaration > remainingDuration) remainingDuration = effect.effectDuaration;
                    break;
                case StackBehavior.uneffective: break;
            }
        }



    }

    public enum EffectType { buff, debuff }
    public enum EffectBehaviour { instant, infinite, durational }


    //when same effect tried the be applied more than once 
    //it will reset the duration  if its resetting
    //it will create a new effect instance if its stackable
    //it will not do anything if its uneffective 
    public enum StackBehavior { resetting, stackable, uneffective }
}