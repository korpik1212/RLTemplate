using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RLTemplate
{
    public class GameManager : MonoBehaviour
    {
        public Dictionary<string, Item> AllItemsById = new Dictionary<string, Item>();
        public PlayerCharacterData activePlayer;
        [SerializeField]
        private Item[] allAvaibleItems;

        private void Awake()
        {
            Initialize();
        }
        private void Initialize()
        {
            activePlayer.characterStats.Initialize();

            for (int i = 0; i < allAvaibleItems.Length; i++)
            {
                Item item = allAvaibleItems[i];
                AllItemsById.Add(item.itemId, item);
            }

        }


    }
}
