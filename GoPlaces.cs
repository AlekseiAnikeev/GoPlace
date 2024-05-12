using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_pointContainer.childCount];

        for (int i = 0; i < _pointContainer.childCount; i++)
            _points[i] = _pointContainer.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var target = _points[_currentPoint];

        transform.position =
            Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
            ChangeNextPlace();
    }

    private void ChangeNextPlace()
    {
        _currentPoint++;

        if (_currentPoint == _points.Length)
            _currentPoint = 0;
    }
}