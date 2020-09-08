using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShooter : MonoBehaviour
{
    [SerializeField]
    private Gun _attachedGun;

    protected IGun _gun
    {
        get 
        {
            //if gun component was deattached or changed
            if(_attachedGun == null)
            {
                _attachedGun = GetComponent<Gun>();
            }

            return _attachedGun;
        }
    }
}
