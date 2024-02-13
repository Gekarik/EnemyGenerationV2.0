using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemy; 
    [SerializeField] private Transform _targetPosition; 
    [SerializeField] private Transform[] _route;
    [SerializeField] private float _delay = 2.0f;

    private void Start()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            yield return wait;
            
            Transform enemy = Instantiate(_enemy, transform.position, Quaternion.identity);

            enemy.GetComponent<Mover>().SetRoute(_route, _targetPosition);
        }
    }
}
