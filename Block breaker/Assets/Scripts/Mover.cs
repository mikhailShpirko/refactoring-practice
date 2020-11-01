using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const float _speed = 0.1f;

    private void Update()
    {
        MoveOverXAxis(Input.GetAxis("Horizontal") * _speed);
    }

    private void MoveOverXAxis(float delta)
    {
        transform.Translate(delta, 0f, 0f);
    }
}
