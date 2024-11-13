using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _turnSmoothTime;
    [SerializeField]
    private Transform _cam;
    private float _turnSmoothVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw( "Horizontal" );
        float vertical = Input.GetAxisRaw( "Vertical" );
        Vector3 direction = new Vector3( horizontal, 0f, vertical ).normalized;

        if (direction.magnitude >= 0.05f)
        {
            _anim.SetBool( "isRunning", true );
            float targetAngle = Mathf.Atan2( direction.x, direction.z ) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle( transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,_turnSmoothTime );
            transform.rotation = Quaternion.Euler( 0f, angle, 0f );
            Vector3 moveDir = Quaternion.Euler( 0f, targetAngle, 0f ) * Vector3.forward;
            _characterController.Move( moveDir.normalized * _movementSpeed * Time.deltaTime );
        }

        //Currently there is a bug when it goes to idle state TODO
    }
}
