using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _targetDistance;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _targetDistance += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Target == null)
            return;

        if (Vector2.Distance(transform.position, Target.transform.position) < _targetDistance)
            NeedTransit = true;        
    }
}
