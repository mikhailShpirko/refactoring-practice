using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    private void OnDisable() 
    {
        OnDestroyed?.Invoke();
    }

    public event Action OnDestroyed; 
}