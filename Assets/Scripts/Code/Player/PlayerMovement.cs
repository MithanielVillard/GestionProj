using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    [Header("Properties")] 
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float acceleration = 20.0f;
    
    //-------
    private NavMeshAgent _agent;
    private bool _isMoving = false;
    //-------

    public UnityEvent _onDestinationReached;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        _agent.acceleration = acceleration;
    }

    private void Update()
    {
        if (_isMoving) CheckDestination();
    }

    public void Move(Vector3 destination)
    {
        _agent.destination = destination;
        _isMoving = true;
    }

    public void Move(Vector3 destination, UnityAction onDestinationReached)
    {
        Move(destination);
        _onDestinationReached.AddListener(onDestinationReached);
        print(onDestinationReached.GetInvocationList()[0]);
    }

    private void CheckDestination()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _onDestinationReached.Invoke();
                    _isMoving = false;
                }
            }
        }
    }
}
