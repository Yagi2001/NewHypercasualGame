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
    private float _swipeSpeed;
    [SerializeField]
    private float _laneDistance;
    private int _currentLane =1; // 0 = Left, 1 = Middle, 2 = Right
    private Vector3 _targetPosition;

    private void Start()
    {
        _anim.SetBool( "isRunning", true );
    }

    private void Update()
    {
        MoveForward();
        HandleLaneSwap();
    }

    private void MoveForward()
    {
        Vector3 forwardMovement = Vector3.forward * _movementSpeed * Time.deltaTime;
        _characterController.Move( forwardMovement );
    }

    private void HandleLaneSwap()
    {
        if ((Input.GetKeyDown( KeyCode.LeftArrow ) || Input.GetKeyDown( KeyCode.A )) && _currentLane > 0)
            _currentLane--;
        else if ((Input.GetKeyDown( KeyCode.RightArrow ) || Input.GetKeyDown( KeyCode.D )) && _currentLane < 2)
            _currentLane++;
        float targetX = (_currentLane - 1) * _laneDistance;
        Vector3 targetPosition = new Vector3( targetX, transform.position.y, transform.position.z );
        Vector3 lateralMovement = Vector3.MoveTowards( transform.position, targetPosition, _swipeSpeed * Time.deltaTime );
        _characterController.Move( lateralMovement - transform.position );
    }
}