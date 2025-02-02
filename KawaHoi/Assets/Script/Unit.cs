using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;
    Vector3 destination;
    public float maxStamina;
    public float curStamina;
    [Range(0, 1)]
    public float needStaminaRatio;
    [SerializeField] float recovStaminaValue;
    public Sprite icon;
    private bool tired;
    void Start()
    {
        UIManager.instance.SetUIObject(this);
        agent = GetComponent<NavMeshAgent>();
        curStamina = maxStamina;
        destination = transform.position;
    }
    private void Update()
    {
        var ratio = Mathf.InverseLerp(0, maxStamina, curStamina);
        //멈춰있을 때
        if (curStamina < maxStamina && agent.velocity.magnitude <= 2)
        {
            curStamina += recovStaminaValue * Time.deltaTime;
            curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
            if (ratio >= needStaminaRatio) tired = false;
        }
        //목적지가 설정됬을 때
        var distance = Vector3.Distance(destination, transform.position);
        print(distance);
        if (distance > 2)
        {
            if (curStamina > 0)
            {
                if(!tired)
                agent.SetDestination(destination);
            }
            else
            {
                agent.SetDestination(transform.position);
                tired = true;
            }
            if (agent.velocity.magnitude >= 2) curStamina -= 2 * Time.deltaTime;
        }
    }
    public virtual void TargetMove(Vector3 targetPos, Structure structure = null)
    {
        destination = targetPos;
    }
}
