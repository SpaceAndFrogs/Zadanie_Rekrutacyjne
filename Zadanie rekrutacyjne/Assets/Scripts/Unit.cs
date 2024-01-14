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
    private float moveSpeedOnFatigueDecrease = 1;
    [SerializeField]
    private BorderlineValues borderlineValues;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    private Transform unitToFollow = null;
    private const int leaderAvoidancePriority = 1;
    private const int followerAvoidancePriority = 50;
    private const float fatigueTick = 0.25f;
    private void Start()
    {
        SetValues(borderlineValues.Attributes);
        StartCoroutine(FatigueCheck());
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
        navMeshAgent.speed = moveSpeed;
    }

    public void FollowTarget(Transform target)
    {
        navMeshAgent.destination = target.position;
        unitToFollow = target;
        navMeshAgent.avoidancePriority = followerAvoidancePriority;
    }

    private IEnumerator FatigueCheck()
    {
        Vector3 lastCheckedPosition = transform.position;
        float currentEndurance = endurance;
        while(true)
        {
            if(lastCheckedPosition != transform.position)
            {
                currentEndurance -= fatigueTick;
                if(currentEndurance<=0)
                {
                    navMeshAgent.speed = moveSpeed / moveSpeedOnFatigueDecrease;
                    currentEndurance = 0;
                }
            }else if(currentEndurance < endurance)
            {
                if(currentEndurance == 0)
                {
                    navMeshAgent.speed = moveSpeed;
                }

                currentEndurance += fatigueTick;
                if(currentEndurance > endurance)
                {
                    currentEndurance = endurance;
                }
            }

            lastCheckedPosition = transform.position;
            yield return new WaitForSeconds(fatigueTick);
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (unitToFollow == null)
            return;

        Unit hittedUnit = collision.collider.GetComponent<Unit>();

        if (hittedUnit != null) 
        {
            if(Vector3.Distance(transform.position,unitToFollow.transform.position) > Vector3.Distance(hittedUnit.transform.position, unitToFollow.transform.position))
            {
                navMeshAgent.speed = 0;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (unitToFollow == null)
            return;
            

        Unit hittedUnit = collision.collider.GetComponent<Unit>();

        if (hittedUnit != null)
        {
            if (Vector3.Distance(transform.position, unitToFollow.transform.position) > Vector3.Distance(hittedUnit.transform.position, unitToFollow.transform.position))
            {
                navMeshAgent.speed = moveSpeed;
            }
        }
    }

}
