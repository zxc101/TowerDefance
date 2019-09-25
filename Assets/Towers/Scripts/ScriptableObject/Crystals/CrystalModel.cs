using Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Model/Crystal", fileName = "NewCrystal.asset")]
public class CrystalModel : ScriptableObject
{
    [Tooltip("Включёный вид")]
    public Sprite spriteOn;

    [Tooltip("Выключёный вид")]
    public Sprite spriteOff;

    [Tooltip("Цвет кристалла")]
    public ColorCrystal color;

    [Tooltip("Пуля")]
    public BulletModel bullet;

    [Tooltip("Скорость стрельбы")]
    public float firingSpeed;
}
