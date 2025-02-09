using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;
    private LineRenderer lineRenderer;
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
        UIManager.instance.SetUIObject(this.gameObject,UIManager.UIState.unit);
        agent = GetComponent<NavMeshAgent>();
        curStamina = maxStamina;
        destination = transform.position;

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.2f;
            lineRenderer.endWidth = 0.2f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
    }
    private void Update()
    {
        MoveObj();
        DrawPath();
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
    public virtual void TargetMove(Vector3 targetPos, Structure structure = null)
    {
        destination = targetPos;
    }
}
