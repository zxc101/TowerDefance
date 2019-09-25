using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Meleer : Enemy
    {
        public void Attack()
        {
            Target.GetComponent<ITakeDamage>().TakeDamage(model.power);
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
