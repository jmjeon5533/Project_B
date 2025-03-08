using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;
    private LineRenderer lineRenderer;
    [HideInInspector] public UnitUI unitUI;
    Vector3 destination;
    public Structure structTarget;

    public float maxHP;
    public float curHP;
    [Space(10)]
    public float maxStamina;
    public float curStamina;
    [Range(0, 1)]
    public float needStaminaRatio;
    [SerializeField] private float recovStaminaValue;

    public Sprite icon;
    private bool tired;
    public bool isEnterStructure;


    Vector3 pos;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        curStamina = maxStamina;
        curHP = maxHP;
        destination = transform.position;

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.2f;
            lineRenderer.endWidth = 0.2f;
            lineRenderer.sharedMaterial = Resources.Load<Material>("Material/AlwaysVisible");
            lineRenderer.sharedMaterial.SetColor("_EmissionColor", Color.white * 5.0f);
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
    }
    private void Update()
    {
        MoveObj();
        DrawPath();
        EnterStructure();
    }
    void MoveObj()
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
        if (distance > 2)
        {
            if (curStamina > 0)
            {
                if (!tired)
                {
                    agent.SetDestination(destination);
                    agent.isStopped = false;
                }
            }
            else
            {
                agent.isStopped = true;
                tired = true;
            }
            if (agent.velocity.magnitude >= 2) curStamina -= 2 * Time.deltaTime;
        }
    }
    void DrawPath()
    {
        if (agent.hasPath)
        {
            NavMeshPath path = agent.path;
            lineRenderer.positionCount = path.corners.Length;
            lineRenderer.SetPositions(path.corners);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }
    void EnterStructure()
    {
        if (structTarget != null)
        {
            var dis = Vector3.Distance(structTarget.transform.position, transform.position);
            if (dis <= 7)
            {
                isEnterStructure = true;
                structTarget.AddUnit(this);
                gameObject.SetActive(false);
                unitUI.gameObject.SetActive(false);
            }
        }
    }

    public virtual void TargetMove(Vector3 targetPos, Structure structure = null)
    {
        Vector3 navMeshPosition;

        if (FindClosestNavMeshPosition(targetPos, out navMeshPosition))
        {
            destination = navMeshPosition;
            pos = navMeshPosition;
        }
    }
    bool FindClosestNavMeshPosition(Vector3 target, out Vector3 result)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(target, out hit, 2.0f, NavMesh.AllAreas)) // 반경 2 유닛 내에서 탐색
        {
            result = hit.position;
            return true;
        }
        result = target;
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pos, 0.5f);
    }
}
