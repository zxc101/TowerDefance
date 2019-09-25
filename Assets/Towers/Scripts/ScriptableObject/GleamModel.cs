using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Model/Gleam", fileName = "NewGleam.asset")]
public class GleamModel : ScriptableObject
{
    [Tooltip("Вид")]
    public Sprite sprite;

    [Tooltip("Цвет луча")]
    public ColorCrystal color;

    [Tooltip("Сила")]
    public int power;
}
