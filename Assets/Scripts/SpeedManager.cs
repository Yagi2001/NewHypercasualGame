using UnityEngine;

[CreateAssetMenu( fileName = "SpeedManager", menuName = "Assets/SpeedManager" )]
public class SpeedManager : ScriptableObject
{
    public float backGroundSpeed; //Enter the initial speed in here from ScriptableAssets -> SpeedManager
    public float speedChangeRate;
}