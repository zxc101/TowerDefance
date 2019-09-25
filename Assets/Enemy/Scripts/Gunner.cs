using Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Gunner : Enemy
    {
        [SerializeField] private Transform bullet;
        [SerializeField] private Transform weapon;

        private void Shoot()
        {
            Vector3 dir = Target.position - transform.position;
            Transform _bullet = Instantiate(bullet, weapon);
            _bullet.GetComponent<Bullet>().SetDirection(dir);
        }

        private void Start()
        {
            Init();
        }

        public override void OnUpdate()
        {
            RaycastHit2D hit = Physics2D.Linecast(eyes.position, attackDistance.position, 1 << LayerMask.NameToLayer("Tower"));
            if (hit)
            {
                Target = hit.transform;
            }
            else
            {
                Target = null;
            }
        }
    }
}