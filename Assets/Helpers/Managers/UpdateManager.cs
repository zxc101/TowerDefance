using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    private readonly List<IUpdate> updates = new List<IUpdate>();
    

    public int Count { get { return updates.Count; } }
    
    public void Add(IUpdate update)
    {
        updates.Add(update);
    }

    public void Remove(IUpdate update)
    {
        updates.Remove(update);
    }

    private void Update()
    {
        for (int i = 0; i < updates.Count; i++)
        {
            updates[i].OnUpdate();
        }
    }
}
