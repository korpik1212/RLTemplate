using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLTemplate
{

    public class EffectManager : MonoBehaviour
    {
        public Dictionary<string, Effect> currentEffectsById = new Dictionary<string, Effect>();
        public CharacterData characterData;
        public void ApplyEffect(Effect effect)
        {
            //because there might be diffrent sources that can apply the same effect its better to check for effect ID rather than reffrence

            if (currentEffectsById.ContainsKey(effect.effectId))
            {

                currentEffectsById[effect.effectId].Stack(effect);

            }
            else
            {
                effect.Activate(characterData);
                currentEffectsById.Add(effect.effectId, effect);
            }
        }

        public void RemoveEffect(string id)
        {
            currentEffectsById.Remove(id);
        }

        public void RemoveEffect(Effect reffrence)
        {
            currentEffectsById.Remove(reffrence.effectId);

        }
    }
}
