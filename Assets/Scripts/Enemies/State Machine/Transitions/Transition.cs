using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;    

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    protected Player Target { get; private set; }
    protected Enemy Enemy { get; private set; }


    private void Start()
    {
        Enemy = GetComponent<Enemy>();   
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(Player target)
    {
        Target = target;
    }    
}
