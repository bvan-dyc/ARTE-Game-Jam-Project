using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statues : MonoBehaviour
{
    [SerializeField] protected List<FacingTrigger> statues = new List<FacingTrigger>();
    protected bool cleared = false;

    public bool IsCleared
    {
        get
        {
            return (cleared);
        }
    }

    private void Update()
    {
        cleared = CheckStatues();
    }

    private bool CheckStatues()
    {
        foreach (FacingTrigger statue in statues)
        {
            int activatedStatues = 0;
            if (statue.IsActivated)
                activatedStatues++;
            return (activatedStatues == statues.Count);
        }
        return false;
    }
}
