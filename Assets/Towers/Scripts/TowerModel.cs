using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Model/Tower", fileName = "NewTower.asset")]
public class TowerModel : ScriptableObject
{
    [Tooltip("Вид")]
    public Sprite sprite;

    [Tooltip("Жизнь")]
    public int HP;
}
