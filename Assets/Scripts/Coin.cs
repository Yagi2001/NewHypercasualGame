using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter( Collider other )
    {
        Debug.Log( "Collected Coin" );
        // update UI and add sound effects
        Destroy( gameObject );
    }
}
