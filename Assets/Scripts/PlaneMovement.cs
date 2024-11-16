using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField]
    private SpeedManager _speedManager;
    private float _speed;

    private void Update()
    {
        _speed = _speedManager.backGroundSpeed;
        transform.Translate( _speed * -1* Time.deltaTime * Vector3.forward );
    }

}
