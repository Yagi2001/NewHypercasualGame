using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [Tooltip( "Value is 1 for plane. Adjust accordingly" )]
    [SerializeField]
    private float _speedMultiplier;
    [SerializeField]
    private SpeedManager _speedManager;
    private float _speed;

    private void Update()
    {
        _speed = _speedManager.backGroundSpeed;
        transform.Translate( _speed*_speedMultiplier * -1* Time.deltaTime * Vector3.forward );
    }

}
