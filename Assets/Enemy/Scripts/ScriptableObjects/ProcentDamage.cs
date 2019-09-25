using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [System.Serializable]
    public struct ProcentDamage
    {
        [Tooltip("Тип кристала")]
        public ColorCrystal color;

        [Tooltip("Процент силы удара")]
        [Range(0, 1)]
        public float procent;
    }
}