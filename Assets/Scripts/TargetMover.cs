using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform[] _route;
    [SerializeField] private float _speed;

    private Vector3 _currentPosition;
    private int _pointCounter = 0;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_currentPosition != _route[_pointCounter].position)
        {
            transform.position = Vector3.MoveTowards(_currentPosition, _route[_pointCounter].position, _speed * Time.deltaTime);
            _currentPosition = transform.position;
        }
        else if(_currentPosition == _route[_route.Length - 1].position)
        {
            Destroy(gameObject);
        }
        else
        {
            _pointCounter++;
        }
    }
}
