using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Model/EnemiesPack", fileName = "EnemiesPack.asset")]
    public class EnemiesPackModel : ScriptableObject
    {
        [Header("Portal Settings")]

        [Tooltip("Волны")]
        public Wave[] waves;
    }
}
