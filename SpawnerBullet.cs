using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpawnerBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _target;

    private void Start() => StartCoroutine(nameof(ShootingWorker));

    private IEnumerator ShootingWorker()
    {
        WaitForSecondsRealtime waitingTime = new WaitForSecondsRealtime(_cooldown);

        while (enabled)
        {
            yield return waitingTime;

            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;
        }
    }
}