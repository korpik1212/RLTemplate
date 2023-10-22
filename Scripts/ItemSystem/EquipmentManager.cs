using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLTemplate
{
    public class EquipmentManager : MonoBehaviour
    {
        public PlayerCharacterData playerCharacterData;
        public Item[] itemSlots;

        private void Awake()
        {
            itemSlots = new Item[System.Enum.GetNames(typeof(ItemType)).Length];
        }
        public void EquipItem(Item item)
        {
            int itemSlotId = (int)item.itemType;
            if (itemSlots[itemSlotId] == null)
            {
                item.Equip(playerCharacterData);
                itemSlots[itemSlotId] = item;
            }
            else if (itemSlots[itemSlotId] != null)
            {
                itemSlots[itemSlotId].Unequip(playerCharacterData);
                item.Equip(playerCharacterData);
                itemSlots[itemSlotId] = item;
            }

        }

        public void UnEquipItem(Item item)
        {
            int itemSlotId = (int)item.itemType;

            item.Unequip(playerCharacterData);
            itemSlots[itemSlotId] = null;
        }
    }
    public enum ItemType { Sword, Armor }
}