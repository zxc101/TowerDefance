using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Model/Enemy", fileName = "NewEnemy.asset")]
    public class EnemyModel : ScriptableObject
    {
        [Header("Enemy settings")]

        [Tooltip("Название врага")]
        public EnemiesNames name;

        [Tooltip("Префаб врага")]
        public Transform prefab;

        [Tooltip("Аниматор")]
        public RuntimeAnimatorController animController;

        [Tooltip("Жизнь")]
        public int HP = 100;

        [Tooltip("Скорость")]
        public float speed = 3;

        [Tooltip("Сила")]
        public int power = 10;

        [Header("Damages")]

        [Tooltip("Проценты сил удара")]
        public List<ProcentDamage> procentsDamage;
    }
}
