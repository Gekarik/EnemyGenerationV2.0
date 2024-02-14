using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private TargetMover _target;
    [SerializeField] private float _delay = 5.0f;

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
            
            EnemyMover enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.SetTarget(_target);
        }
    }
}
