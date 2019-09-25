using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enemies;

[System.Serializable]
public class Group
{
    [Tooltip("Время респауна между группами персонажей")]
    public float respawnGroup = 1;

    [Tooltip("Время респауна между персонажами")]
    public float respawnCharacter = 1;

    [Tooltip("Модель врага")]
    public EnemyModel enemyModel;

    [Tooltip("Количество противников")]
    public int count = 1;
}
