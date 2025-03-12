using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    [Header("Properties")] 
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float acceleration = 20.0f;
    
    //-------
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        _agent.acceleration = acceleration;
    }

    public void Move(Vector3 destination)
    {
        _agent.destination = destination;
    }
}
