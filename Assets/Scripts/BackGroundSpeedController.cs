using UnityEngine;

public class BackGroundSpeedController : MonoBehaviour
{
    [SerializeField]
    private SpeedManager _speedManager;
    [SerializeField]
    private float _initialSpeed;
    [SerializeField]
    private float _initialSpeedChangeRate;

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
        _speedManager.backGroundSpeed = 0;
        _speedManager.speedChangeRate = 0f;
    }

    void Update()
    {
        IncreaseSpeedOverTime();
    }

    private void ChangeInitialSpeed()
    {
        _speedManager.backGroundSpeed = _initialSpeed;
        _speedManager.speedChangeRate = _initialSpeedChangeRate;
    }

    private void IncreaseSpeedOverTime()
    {
        _speedManager.backGroundSpeed += _speedManager.speedChangeRate * Time.deltaTime;
    }
}
