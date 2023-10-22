
using UnityEngine;

namespace RLTemplate
{

    //I try to refain from using scriptable objects if the class only has 2-3 modifiable values to keep project simpler
    [System.Serializable]
    public class StatModifier
    {
        public string statId;
        public int order;
        public ModifierType modifierType;
        public float value;
        [HideInInspector]
        public object source;



     
        public StatModifier(float value, ModifierType modifierType, int order, object source)
        {
            this.order = order;
            this.value = value;
            this.modifierType = modifierType;
            this.source = source;
        }

        public StatModifier(float value, ModifierType type) : this( value, type, (int)type, null) { }
        public StatModifier(float value, ModifierType type, object source) : this( value, type, (int)type, source) { }

    }

    public enum ModifierType { Addition, Multipication }
}