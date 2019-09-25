using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int HP;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP < 0)
        {
            Destroy(gameObject);
        }
    }
}
