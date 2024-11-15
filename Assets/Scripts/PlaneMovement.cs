using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private float _originalSpeed;

    private void OnEnable()
    {
        PlayerMovement.FinishedMoving += ChangeInitialSpeed;
    }

    private void OnDisable()
    {
        PlayerMovement.FinishedMoving -= ChangeInitialSpeed;
    }

    private void Start()
    {
        _originalSpeed = _speed;
        _speed = 0; //This is used to prevent the plane from moving while player is moving.
    }

    private void Update()
    {
        transform.Translate( _speed * -1* Time.deltaTime * Vector3.forward );
    }

    private void ChangeInitialSpeed()
    {
        _speed = _originalSpeed;
    }
}
