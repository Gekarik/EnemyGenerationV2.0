using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private TargetMover _target;

    private void Update()
    {
        Move();
    }

    public void SetTarget(TargetMover target)
    {
        _target = target;
    }

    private void Move()
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }
}
