using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : MonoBehaviour
{
    public virtual void Trigger()
    {
        Debug.Log("Triggered");
    }
}
