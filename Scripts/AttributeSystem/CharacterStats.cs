using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLTemplate
{
    [CreateAssetMenu(menuName ="Attributes/CharacterStats")]
    public class CharacterStats : ScriptableObject
    {

       

        public Dictionary<string, Stat> StatsByID = new Dictionary<string, Stat>();
        [SerializeField]
        private Stat[] characterStats;

        bool initialized = false;
        //its also possible to create CharacterStats individually as shown below 

        //public CharacterStat attackDamage;
        //public CharacterStat attackSpeed;
        //public CharacterStat movementSpeed;

        public void Initialize()
        {
            if (initialized) return;
            for(int i = 0; i < characterStats.Length; i++)
            {
                Stat characterStat = characterStats[i];
                StatsByID.Add(characterStat.statId, characterStat);
            }

            initialized = true;

        }

   

        public Stat GetStatByID(string id)
        {
            return StatsByID[id];
        }



        public void RemoveAllModifiersBySource(object source)
        {
          foreach(KeyValuePair<string,Stat> stat in StatsByID)
            {
                stat.Value.RemoveAllModifiersBySource(source);
            }
        }
        public void RemoveAllModifiers()
        {
            foreach (KeyValuePair<string, Stat> stat in StatsByID)
            {
                stat.Value.RemoveAllModifiers();
            }
        }
    }
}
