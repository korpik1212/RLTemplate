using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace RLTemplate
{
    public class ItemTest
    {


        [UnityTest]
        public IEnumerator EquipItemTest()
        {

            SceneManager.LoadScene("GameScene");
            yield return null;
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            Item frostMourne = gameManager.AllItemsById["sword_frostmourne"];
            PlayerCharacterData playerCharacterData = gameManager.activePlayer;
            playerCharacterData.equipmentManager.EquipItem(frostMourne);
            Assert.AreEqual(frostMourne, playerCharacterData.equipmentManager.itemSlots[0]);
        }

        [UnityTest]
        public IEnumerator FrostmourneEffectTest()
        {
            SceneManager.LoadScene("GameScene");
            yield return null;
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            FrostMourne frostMourne = (FrostMourne)gameManager.AllItemsById["sword_frostmourne"];
            PlayerCharacterData playerCharacterData = gameManager.activePlayer;

            playerCharacterData.equipmentManager.EquipItem(frostMourne);
            frostMourne.AttackEffect(playerCharacterData);



            //check if effect is applied
            Assert.IsTrue(playerCharacterData.effectManager.currentEffectsById.ContainsKey("effect_frostbite"));

        }
    }
}