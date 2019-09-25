using Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private CrystalModel model;

    private bool isActive;
    private SpriteRenderer spriteRenderer;

    public ColorCrystal color { get { return model.color; } }
    public float firingSpeed { get { return model.firingSpeed; } }
    public int power { get { return model.bullet.power; } }
    public Transform bullet { get { return model.bullet.prefab; } }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = model.spriteOff;
    }

    public void Tumbler()
    {
        isActive = !isActive;

        if (isActive)
        {
            spriteRenderer.sprite = model.spriteOn;
        }
        else
        {
            spriteRenderer.sprite = model.spriteOff;
        }
    }
}
