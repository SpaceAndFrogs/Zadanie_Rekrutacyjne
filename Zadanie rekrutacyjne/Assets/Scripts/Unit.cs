using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    private float moveSpeed;
    private float agility;
    private float endurance;
    [SerializeField]
    private BorderlineValues borderlineValues;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    private Transform unitToFollow = null;
    private const int leaderAvoidancePriority = 1;
    private const int followerAvoidancePriority = 50;
    private void Start()
    {
        SetValues(borderlineValues.Attributes);
    }

    
    private void FixedUpdate()
    {
        if (unitToFollow != null)
        {
            navMeshAgent.destination = unitToFollow.position;
        }
    }

    private void SetValues(BorderlineValues.Attribute[] attributes)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            switch (attributes[i].AttributeType)
            {
                case BorderlineValues.AttributesType.MoveSpeed:
                    {
                        moveSpeed = Random.Range(attributes[i].MinMax.x, attributes[i].MinMax.y);
                        break;
                    }
                case BorderlineValues.AttributesType.Agility:
                    {
                        agility = Random.Range(attributes[i].MinMax.x, attributes[i].MinMax.y);
                        break;
                    }
                case BorderlineValues.AttributesType.Endurance:
                    {
                        endurance = Random.Range(attributes[i].MinMax.x, attributes[i].MinMax.y);
                        break;
                    }

            }

            navMeshAgent.speed = moveSpeed;
            navMeshAgent.angularSpeed = agility;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        navMeshAgent.destination = destination;
        unitToFollow = null;
        navMeshAgent.avoidancePriority = leaderAvoidancePriority;
    }

    public void FollowTarget(Transform target)
    {
        navMeshAgent.destination = target.position;
        unitToFollow = target;
        navMeshAgent.avoidancePriority = followerAvoidancePriority;
    }
}
