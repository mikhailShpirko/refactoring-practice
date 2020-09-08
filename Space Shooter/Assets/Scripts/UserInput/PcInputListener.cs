using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputListener : BaseUserInputListener
{
    private void Update()
    {
        ChangeMovementInput(Input.GetAxis("Horizontal"));
        ChangeShootInput(Input.GetKeyDown(KeyCode.Space));
    }

    private void ChangeMovementInput(float newValue)
    {
        if(newValue != 0)
        {
            InvokeOnMovementInputChanged(newValue);
        }
    }

    private void ChangeShootInput(bool newValue)
    {
        if(newValue)
        {
            InvokeOnShootInputPressed();
        }
    }
}
