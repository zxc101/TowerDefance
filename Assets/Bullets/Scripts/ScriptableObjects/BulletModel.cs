using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    [CreateAssetMenu(menuName = "Model/Bullet", fileName = "NewBullet.asset")]
    public class BulletModel : ScriptableObject
    {
        [Tooltip("Префаб пули")]
        public Transform prefab;

        [Tooltip("Вид")]
        public Sprite sprate;

        [Tooltip("Сила")]
        public int power;

        [Tooltip("Скорость")]
        public float speed;
    }
}
