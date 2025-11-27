using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Character : MonoBehaviour
{
    public Animator Anim => animator;
    [SerializeField] Animator animator;

    protected CharacterStateMachine stateMachine;

    public CharacterStatus Status => status; 
    protected CharacterStatus status;

    public NavMeshAgent Agent => agent;
    private NavMeshAgent agent;

    public event Action OnHitAction;
    public event Action OnAttackAction;
    public event Action OnDieAction;


    protected abstract void Init();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        status = GetComponent<CharacterStatus>();
        agent.speed = status.MoveSpeed;
        
        Init();
    }


    private void Start()
    {
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

    public void TakeDamage( int damage )
    {
        status.AddHealth(-damage);
        OnHitAction?.Invoke();

        if ( status.NowHealth <= 0 )
            Die();
    }

    public virtual void Attack()
    {
    }

    public void Die()
    {
        OnDieAction?.Invoke();
    }


    public abstract void Respawn();
    

    protected abstract void UpdateInternal();

    
    public Coroutine StartDelayAction(Action action, float delay)
    {
        return StartCoroutine(DelayActionRoutine(action, delay));
    }
    IEnumerator DelayActionRoutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
