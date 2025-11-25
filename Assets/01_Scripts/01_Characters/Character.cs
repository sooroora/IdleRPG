using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    protected CharacterStateMachine stateMachine;
    
    public NavMeshAgent Agent => agent;
    private NavMeshAgent agent;

    public virtual Transform Target => target?.transform;
    private Transform target;
    
    Animator animator;
    public event Action OnHitAction;
    public event Action OnAttackAction;



    protected abstract void Init();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Init();
    }

    protected void Update()
    {
        stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        stateMachine?.FixedUpdate();
    }

    protected void SetTarget(Transform _target)
    {
        target = _target;
    }


}
