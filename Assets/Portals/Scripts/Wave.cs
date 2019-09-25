using UnityEngine;

[System.Serializable]
public class Wave
{
    [Tooltip("Время респауна между волнами")]
    public float respawnWave = 1;

    [Range(1, 3)]
    public int level = 1;

    [Tooltip("Группы врагов")]
    public Group[] groups;
}
