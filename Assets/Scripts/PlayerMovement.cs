using System.Collections;
using UnityEngine;
using System;

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
    public static Action FinishedMoving;

    private void Start()
    {
        _anim.SetBool( "isRunning", true );
        StartCoroutine( MoveForward() ); // This initial movement added for a more realistic climbing with physics
    }

    private void Update()
    {
        HandleLaneSwap();
    }

    private IEnumerator MoveForward()
    {
        float timeElapsed = 0f;
        while (timeElapsed < 2f)
        {
            Vector3 forwardMovement = Vector3.forward * _movementSpeed * Time.deltaTime;
            _characterController.Move( forwardMovement );
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        FinishedMoving?.Invoke();
        //After that coroutine our character will stay on his place and objects, background etc. will move like other endless runners
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