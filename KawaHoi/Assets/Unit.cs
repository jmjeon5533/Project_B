using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public virtual void TargetMove(Vector3 targetPos, Structure structure = null)
    {
        agent.SetDestination(targetPos);
    }
}
