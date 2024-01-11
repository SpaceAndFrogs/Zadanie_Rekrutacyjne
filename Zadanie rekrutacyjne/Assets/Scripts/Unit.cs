using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private float moveSpeed;
    private float agility;
    private float endurance;
    private float jumpHeight;
    [SerializeField]
    private BorderlineValues borderlineValues;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    private Transform unitToFollow = null;
    private void Start()
    {
        
    }

    
    private void FixedUpdate()
    {
        
    }

    private void SetValues(BorderlineValues.Attribute[] attributes)
    {

    }

    public void SetDestination(Vector3 destination)
    {

    }

    public void FollowTarget(Transform target)
    {

    }
}
