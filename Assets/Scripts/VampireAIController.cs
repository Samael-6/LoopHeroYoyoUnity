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
    [SerializeField] private GameObject navpoint;
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
            case StateType.Follow:
                if(Vector3.Distance(target.transform.position, transform.position) <= rangeAttack)
                {
                    newstatetype = StateType.Attack;
                    return true;
                }
                break;
        }
        return false;
    }

    private void ChangeState()
    {
        EndState();
        state = newstatetype;
        StartState();
    }

    private void StartState()
    {
        switch (state)
        {
            case StateType.Attack:
                break;
        }
    }

    private void EndState()
    {
        switch (state)
        {
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
        GetComponent<NavMeshAgent>().SetDestination(navpoint.transform.position);
    }

    private void FollowBehaviour()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }

    private void AttackBehaviour()
    {
        GetComponent<Animator>().SetTrigger(name:"Bite");
    }
}
