using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : BaseShooter
{
    private void Update()
    {
        _gun?.Shoot();
    }
}
