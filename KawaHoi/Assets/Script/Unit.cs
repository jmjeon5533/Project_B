using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;
    Vector3 destination;
    public float maxStamina;
    public float curStamina;
    public float needStaminaRatio;
    [SerializeField] float recovStaminaValue;
    void Start()
    {
        UIManager.instance.SetUIObject(this);
        agent = GetComponent<NavMeshAgent>();
        curStamina = maxStamina;
        needStaminaRatio = 0.5f;
        recovStaminaValue = 0.5f;
        destination = transform.position;
    }
    private void Update()
    {
        //멈춰있을 때
        if (curStamina < maxStamina && agent.velocity.magnitude <= 2)
        {
            curStamina += recovStaminaValue * Time.deltaTime;
            curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
        }
        //목적지가 설정됬을 때
        if (Vector3.Distance(destination, transform.position) > 2)
        {
            if (curStamina >= Mathf.Lerp(0,maxStamina,needStaminaRatio))
            {
                agent.SetDestination(destination);
            }
            if (curStamina <= 0)
            {
                agent.SetDestination(transform.position);
            }
            else
            {
                if(agent.velocity.magnitude >= 2) curStamina -= 2 * Time.deltaTime;
            }
        }
    }
    public virtual void TargetMove(Vector3 targetPos, Structure structure = null)
    {
        destination = targetPos;
    }
}
