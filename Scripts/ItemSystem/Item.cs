using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RLTemplate;

namespace RLTemplate
{
    public class Item : ScriptableObject
    {

        public ItemType itemType;
        public string itemId;
        public string itemName;
        public string itemDescription;
        public List<StatModifier> statBonuses = new List<StatModifier>();

        public void Equip(PlayerCharacterData playerCharacterData)
        {
            foreach (StatModifier statModifier in statBonuses)
            {
                playerCharacterData.characterStats.GetStatByID(statModifier.statId).AddModifier(statModifier);
            }
        }

        public void Unequip(PlayerCharacterData playerCharacterData)
        {

        }
    }
}
