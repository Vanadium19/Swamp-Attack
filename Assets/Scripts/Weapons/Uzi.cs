using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private int _queueShootsCount;
    [SerializeField] private float _delay;

    private Coroutine _shooting;

    public override void Shoot(Transform shootPoint)
    {
        StopShootQueue();
        StartShootQueue(shootPoint);
    }

    private void StartShootQueue(Transform shootPoint)
    {
        _shooting = StartCoroutine(ShootQueue(shootPoint));
    }

    private void StopShootQueue()
    {
        if (_shooting != null)
            StopCoroutine(_shooting);
    }

    private IEnumerator ShootQueue(Transform shootPoint)
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _queueShootsCount; i++)
        {            
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            yield return wait;
        }
    }
}
