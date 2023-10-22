using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RLTemplate
{
    [CreateAssetMenu(menuName = "Items/FrostMourne")]
    public class FrostMourne : Item
    {
        public FrostBite frostBiteEffect;
        public void AttackEffect(CharacterData target)
        {

            target.effectManager.ApplyEffect(frostBiteEffect);
        }

    }
}
