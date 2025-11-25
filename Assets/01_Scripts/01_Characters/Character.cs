using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    
    protected CharacterStateMachine stateMachine;
    protected CharacterStatus status;
    
    public NavMeshAgent Agent => agent;
    private NavMeshAgent agent;

    public virtual Transform Target => target?.transform;
    private Transform target;
    
    public event Action OnHitAction;
    public event Action OnAttackAction;



    protected abstract void Init();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<CharacterStatus>();
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
