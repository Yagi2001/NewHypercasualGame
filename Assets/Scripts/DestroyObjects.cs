using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private float _destroyThreshold = -650f;
    private void Update()
    {
        if (transform.position.z <= _destroyThreshold)
            Destroy( gameObject );
    }
}
