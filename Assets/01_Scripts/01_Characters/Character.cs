using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    protected CharacterStateMachine stateMachine;


    public NavMeshAgent Agent => agent;
    private NavMeshAgent agent;

    public Transform Target => targetEnemy?.transform;
    private Character targetEnemy;
    
    

    protected abstract void Init();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Init();
    }

    private void Update()
    {
        stateMachine?.HandleInput();
        stateMachine?.Update();
    }


    private void FixedUpdate()
    {
        stateMachine?.FixedUpdate();
    }


}
