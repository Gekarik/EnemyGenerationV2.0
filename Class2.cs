using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] public float _speed;
    [SerializeField] private float _delayBeforeShooting;

    public Transform _target;

    private void Start()
    {
        StartCoroutine(nameof(Shoot));
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        var wait = new WaitForSeconds(_delayBeforeShooting);

        while (isWork)
        {
            Vector3 shootDirection = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_prefab, transform.position + shootDirection, Quaternion.identity);
            var rigidBodyComponent = bullet.GetComponent<Rigidbody>();

            rigidBodyComponent.transform.up = shootDirection;
            rigidBodyComponent.velocity = shootDirection * _speed * Time.deltaTime;

            yield return wait;
        }
    }
}