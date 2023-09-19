using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiedTransition : Transition
{
    private void Update()
    {
        if (Enemy.Health <= 0)
            NeedTransit = true;
    }
}
