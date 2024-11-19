using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineBrain _cinemachineBrain;
    private void OnEnable()
    {
        _cinemachineBrain = GetComponent<CinemachineBrain>();
        Debug.Log( _cinemachineBrain );
        PlayerMovement.FinishedMoving += TurnOffCineMachine;
    }

    private void OnDisable()
    {
        PlayerMovement.FinishedMoving -= TurnOffCineMachine;
    }

    private void TurnOffCineMachine()
    {
        _cinemachineBrain.enabled = false;
    }
}
