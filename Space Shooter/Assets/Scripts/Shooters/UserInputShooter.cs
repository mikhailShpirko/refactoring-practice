using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputShooter : BaseShooter
{
    [SerializeField]
    private BaseUserInputListener _userInputListener;

    private void OnEnable() 
    {
        _userInputListener.OnShootInputPressed += _gun.Shoot;
    }

    private void OnDestroy() 
    {
        _userInputListener.OnShootInputPressed -= _gun.Shoot;
    }
}
