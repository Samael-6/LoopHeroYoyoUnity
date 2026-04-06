using UnityEngine;
using UnityEngine.AI;

public enum StateType
{
    None,
    Patrol,
    Follow,
    Attack
}

public class VampireAIController : MonoBehaviour
{

    [SerializeField] private StateType state = StateType.None;
    [SerializeField] private StateType newstatetype = StateType.None;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 navpoint;
    [SerializeField] private float rangeAttack = 1.5f;

    private void Update()
    {
        if (TestChangeState())
        {
            ChangeState();
        }
        BehaviourAction();
    }

    private bool TestChangeState()
    {
        switch (state)
        {
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            case StateType.Attack:
                if(!GetComponent<SightPerception>().isDeteced)
                {
                    newstatetype = StateType.Patrol;
                    return true;
                }

                if(Vector3.Distance(target.transform.position, transform.position) > rangeAttack)
                {
                    newstatetype = StateType.Follow;
                    return true;
                }

                break;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            case StateType.Patrol:
                if(GetComponent<SightPerception>().isDeteced)
                {
                    if (Vector3.Distance(target.transform.position, transform.position) <= rangeAttack)
                    {
                        newstatetype = StateType.Attack;
                        return true;
                    }

                    newstatetype = StateType.Follow;
                    return true;
                }

                break;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            case StateType.Follow:

                if (!GetComponent<SightPerception>().isDeteced)
                {
                    newstatetype = StateType.Patrol;
                    return true;
                }

                if (Vector3.Distance(target.transform.position, transform.position) <= rangeAttack)
                {
                    newstatetype = StateType.Attack;
                    return true;
                }
                break;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        return false;
    }

    private void ChangeState()
    {
        EndState();
        state = newstatetype;
        StartState();
    }

    public StateType GetState()
    {
        return state;
    }

    private void StartState()
    {
        switch (state)
        {
            case StateType.Patrol:
                GetComponent<NavMeshAgent>().speed = 3.5f;
                break;

            case StateType.Follow:
                GetComponent<NavMeshAgent>().speed = 5f;
                break;

            case StateType.Attack:
                break;
        }
    }

    private void EndState()
    {
        switch (state)
        {
            case StateType.Patrol:
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
                break;

            case StateType.Follow:
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
                break;
        }
    }

    private void BehaviourAction()
    {
        switch (state)
        {
            case StateType.Patrol:
                PatrolBehaviour();
                break;

            case StateType.Follow:
                FollowBehaviour();
                break;

            case StateType.Attack:
                AttackBehaviour();
                break;
        }
    }

    private void PatrolBehaviour()
    {
        GetComponent<NavMeshAgent>().SetDestination(navpoint);
        GetComponent<Animator>().SetFloat(name:"Speed", GetComponent<NavMeshAgent>().velocity.magnitude);
        if (Vector3.Distance(transform.position, navpoint) < 1f)
        {
            navpoint = GetRandomNavMeshPoint();
        }
    }

    private void FollowBehaviour()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        GetComponent<Animator>().SetFloat(name: "Speed", GetComponent<NavMeshAgent>().velocity.magnitude);
    }

    private void AttackBehaviour()
    {
        GetComponent<Animator>().SetTrigger(name:"Punch");
    }

    private Vector3 GetRandomNavMeshPoint()
    {
        Vector3 randomPoint = new Vector3(Random.Range(-18, 18), 0, Random.Range(-18, 18));

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 5f, NavMesh.AllAreas))
            return hit.position;
        else
            return GetRandomNavMeshPoint();
    }
}
