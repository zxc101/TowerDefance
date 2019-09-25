using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bullets;
using Enemies;

public class Trunk : MonoBehaviour
{
    public void Shoot(Transform target)
    {
        Vector3 dir = target.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Transform _bullet = Instantiate(EnemiesPack.crystal.bullet, transform.position, Quaternion.Euler(0, 0, angle), transform);
        _bullet.GetComponent<Bullet>().SetDirection(dir);
        _bullet.GetComponent<Bullet>().SetTarget(target.GetComponent<Enemy>().Name);
    }
}
