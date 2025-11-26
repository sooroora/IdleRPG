using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Character : MonoBehaviour
{
    public Animator Anim => animator;
    [SerializeField] Animator animator;

    protected CharacterStateMachine stateMachine;
    protected CharacterStatus status;

    public NavMeshAgent Agent => agent;
    private NavMeshAgent agent;

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
        UpdateInternal();
    }

    private void FixedUpdate()
    {
        stateMachine?.FixedUpdate();
    }


    public void LookAtTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0; 
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    protected abstract void UpdateInternal();

}
