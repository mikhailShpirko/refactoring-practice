using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUserInputListener : MonoBehaviour
{
    public event Action<float> OnMovementInputChanged;

    public event Action OnShootInputPressed;
    
    protected void InvokeOnMovementInputChanged(float movementInput)
    {
        OnMovementInputChanged?.Invoke(movementInput);
    }

    protected void InvokeOnShootInputPressed()
    {
        OnShootInputPressed?.Invoke();
    }
}
