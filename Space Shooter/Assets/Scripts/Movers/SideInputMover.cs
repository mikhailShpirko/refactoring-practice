using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideInputMover : MonoBehaviour
{
    [SerializeField]
    private BaseUserInputListener _userInputListener;

    [SerializeField]
    private Transform _targetTransfrom;

    [SerializeField]
    private float _speed;


    private void OnEnable() 
    {
        _userInputListener.OnMovementInputChanged += Move;
    }

    private void OnDestroy() 
    {
        _userInputListener.OnMovementInputChanged -= Move;
    }
    
    private void Move(float delta)
    {
        _targetTransfrom.Translate(new Vector3(delta * _speed, 0f, 0f));
    }

}
