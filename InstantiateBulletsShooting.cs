using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _objectToShoot;

    private void Start() => StartCoroutine(nameof(ShootingWorker));

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            yield return new WaitForSecondsRealtime(_cooldown);
            
            var direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;
        }
    }
}