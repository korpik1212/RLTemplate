using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace RLTemplate
{

    public class ResourceTest
    {
        [Test]
        public void ItemsTest()
        {
            Item[] items = Resources.LoadAll<Item>("Items");
            List<string> pastIds = new List<string>();
            for (int i = 0; i < items.Length; i++)
            {
                Assert.IsTrue(!pastIds.Contains(items[i].itemId));
                pastIds.Add(items[i].itemId);
                Assert.AreNotEqual("", items[i].itemId);
            }
        }
        [Test]
        public void StatsTest()
        {
            Stat[] stats = Resources.LoadAll<Stat>("Attributes/Stats");
            List<string> pastIds = new List<string>();
            for (int i = 0; i < stats.Length; i++)
            {
                Assert.IsTrue(!pastIds.Contains(stats[i].statId));
                pastIds.Add(stats[i].statId);
                Assert.AreNotEqual("", stats[i].statId);
            }
        }
        [Test]
        public void EffectsTest()
        {

            Effect[] effects = Resources.LoadAll<Effect>("Effects");
            List<string> pastIds = new List<string>();
            for (int i = 0; i < effects.Length; i++)
            {
                //game architecture allows multiple diffrent effects with the same id so we are not checking if there is more than one with the same id

                Assert.AreNotEqual("", effects[i].effectId);
            }

        }
    }
}
