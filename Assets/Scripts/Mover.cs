using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform[] _route;
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

    public void SetRoute(Transform[] route, Transform targetPosition)
    {
        _route = new Transform[route.Length + 1];

        for (int i = 0; i < route.Length; i++)
            _route[i] = route[i];

        _route[_route.Length - 1] = targetPosition;
    }

    private void Move()
    {
        if (_currentPosition == _route[_pointCounter].position && _currentPosition != _route[_route.Length - 1].position)
        {
            _pointCounter++;
        }
        else if (_currentPosition == _route[_route.Length - 1].position)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(_currentPosition, _route[_pointCounter].position, _speed * Time.deltaTime);
            _currentPosition = transform.position;
        }
    }
}
