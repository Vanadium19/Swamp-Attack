using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += ChangeValueTo;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= ChangeValueTo;
    }
}
