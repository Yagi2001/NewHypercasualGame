using UnityEngine;

public class PlaneLoop : MonoBehaviour
{
    [SerializeField]
    private Transform _planeParent; //Parent object's child Planes must be added in order
    private Transform[] _planePool; 
    [SerializeField]
    private float _resetThreshold = -400f;
    private int _currentIndex;
    private float _planeLength;

    private void Start()
    {
        _planePool = new Transform[_planeParent.childCount];
        for (int i = 0; i < _planeParent.childCount; i++)
        {
            _planePool[i] = _planeParent.GetChild( i );
        }
        _currentIndex = 0;
        _planeLength = _planePool[0].transform.localScale.z;
    }

    private void Update()
    {
        if (_planePool[_currentIndex].transform.position.z <= _resetThreshold)
        {
            RepositionPlane();
            _currentIndex = (_currentIndex + 1) % _planePool.Length;
        }
    }

    private void RepositionPlane()
    {
        int targetIndex = (_currentIndex - 1 + _planePool.Length) % _planePool.Length;
        _planePool[_currentIndex].transform.localPosition = new Vector3( 0f, 0f, _planePool[targetIndex].transform.localPosition.z + _planeLength );
    }
}
