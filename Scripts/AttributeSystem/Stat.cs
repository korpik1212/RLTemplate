using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RLTemplate
{
    [CreateAssetMenu(menuName ="Attributes/CharacterStat")]
    public class Stat:ScriptableObject
    {
        public string statName;
        public string statId;
        public string statDescription;
        public Sprite statSprite;

     
        protected List<StatModifier> statModifiers = new List<StatModifier>();
        public StatType statType;
        public float baseValue;
        [HideInInspector]
        public float maxValue;
        [HideInInspector]
        public float currentValue;
        public delegate void CurrentValueChanged();
        public event CurrentValueChanged OnCurrentValueChanged;
        protected bool isDirty = true;
        private float _value;
        public float value
        {
            get
            {
                if (isDirty)
                {
                    _value = GetFinalValue();
                    isDirty = false;
                }

                return _value;
            }

        }
        


        public void AddModifier(StatModifier modifier)
        {

            float changeValue = 0;
            float valueBeforeChange = value;
            statModifiers.Add(modifier);
            changeValue = value - valueBeforeChange;
            if (statType == StatType.dynamicStatAutoFill && changeValue > 0) ChangeCurrentValue(changeValue);
            isDirty = true;
            statModifiers.OrderBy(x1 => x1.order);
        }

        public void RemoveModifier(StatModifier modifier)
        {
            bool modifierRemoved = statModifiers.Remove(modifier);
            isDirty = true;


        }

        public void RemoveAllModifiers()
        {
            statModifiers.Clear();
        }

        public void RemoveAllModifiersBySource(object source)
        {
            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].source == source)
                {
                    statModifiers.RemoveAt(i);
                    isDirty = true;

                }
            }
        }


        private float GetFinalValue()
        {
            float returnValue = baseValue;
            float extraMultipicationValue = 0;
            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier modifier = statModifiers[i];

                switch (modifier.modifierType)
                {
                    case ModifierType.Addition: returnValue += modifier.value; break;
                    case ModifierType.Multipication: extraMultipicationValue +=  modifier.value; break;
                    default:
                        Debug.LogError("Unknown Modifier Type");
                        break;
                }
            }

            returnValue *= (1 + extraMultipicationValue);
            extraMultipicationValue = 0;
            return returnValue;
        }



        public void ChangeCurrentValue(float changeAmount)
        {
            currentValue += changeAmount;
            OnCurrentValueChanged?.Invoke();

        }

        //in this template max value and value is the same if you want to change this behaviour you can change this method
        public float GetMaxValue()
        {
            switch (statType)
            {
                case StatType.fixedStat: return GetFinalValue();
                case StatType.dynamicStat: return GetFinalValue();
                case StatType.dynamicStatAutoFill: return GetFinalValue();
                default: return GetFinalValue();
            }

        }
    }
    public enum StatType { fixedStat, dynamicStat,dynamicStatAutoFill }

}
