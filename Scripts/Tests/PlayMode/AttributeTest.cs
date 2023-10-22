using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace RLTemplate
{
    public class AttributeTest
    {


        [UnityTest]
        public IEnumerator AttributeAdditionTest()
        {

            int amount = 5;
            SceneManager.LoadScene("GameScene");
            yield return null;
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            Assert.NotNull(gameManager);
            Assert.NotNull(gameManager.activePlayer);
            Assert.NotNull(gameManager.activePlayer.characterStats);
            gameManager.activePlayer.characterStats.RemoveAllModifiers();

            foreach (KeyValuePair<string, Stat> characterStat in gameManager.activePlayer.characterStats.StatsByID)
            {

                characterStat.Value.AddModifier(new StatModifier(amount, ModifierType.Addition));
                Assert.AreEqual(characterStat.Value.baseValue + amount, characterStat.Value.value);
            }


        }

        [UnityTest]
        public IEnumerator AttributeMultipicationTest()
        {
            int amount = 5;
            SceneManager.LoadScene("GameScene");
            yield return null;
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

            Assert.NotNull(gameManager);
            Assert.NotNull(gameManager.activePlayer);
            Assert.NotNull(gameManager.activePlayer.characterStats);
            gameManager.activePlayer.characterStats.RemoveAllModifiers();
            foreach (KeyValuePair<string, Stat> characterStat in gameManager.activePlayer.characterStats.StatsByID)
            {
                characterStat.Value.AddModifier(new StatModifier(amount, ModifierType.Multipication));
                Assert.AreEqual(characterStat.Value.baseValue * (1 + amount), characterStat.Value.value);
            }


        }


        //typically its not a good practice to use random values in test but in this spesific case we dont need a deterministic test we already do that above instead we check for edge case scenerios we might not have think of
        [UnityTest]
        public IEnumerator AttributeRandomTest()
        {
            SceneManager.LoadScene("GameScene");
            yield return null;
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

            gameManager.activePlayer.characterStats.RemoveAllModifiers();

            foreach (KeyValuePair<string, Stat> characterStat in gameManager.activePlayer.characterStats.StatsByID)
            {
                int multipicaitonAmount = 0;
                int additionAmount = 0;
                int modificationAmount = Random.Range(5, 10);
                for (int i = 0; i < modificationAmount; i++)
                {
                    int randomType = Random.Range(0, System.Enum.GetValues(typeof(ModifierType)).Length);
                    int randomValue = Random.Range(-10, 10);
                    characterStat.Value.AddModifier(new StatModifier(randomValue, ((ModifierType)randomType)));

                    if (((ModifierType)randomType) == ModifierType.Addition)
                    {
                        additionAmount += randomValue;
                    }
                    if (((ModifierType)randomType) == ModifierType.Multipication)
                    {
                        multipicaitonAmount += randomValue;

                    }

                }
                Assert.AreEqual((characterStat.Value.baseValue + additionAmount) * (1 + multipicaitonAmount), characterStat.Value.value);
            }


        }

    }
}