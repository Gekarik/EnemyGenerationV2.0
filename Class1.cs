using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    public Transform _placesContainer;
    private Transform[] _places;
    private int _placesCounter;
    public float _speed;

    private void Start()
    {
        _places = new Transform[_placesContainer.childCount];

        for (int i = 0; i < _placesContainer.childCount; i++)
            _places[i] = _placesContainer.GetChild(i).GetComponent<Transform>();
    }
    
    public void Update()
    {
        var currentTarget = _places[_placesCounter];

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == currentTarget.position) 
            TakeNextPlace();
    }

    public Vector3 TakeNextPlace()
    {
        _placesCounter++;

        if (_placesCounter == _places.Length)
            _placesCounter = 0;

        var _placePosition = _places[_placesCounter].transform.position;

        transform.forward = _placePosition - transform.position;

        return _placePosition;
    }
}