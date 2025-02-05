using UnityEngine;

public class TargetUI : MonoBehaviour
{
    [SerializeField] Vector3 offsetPos = new Vector3(0,2,0);
    public GameObject targetObject;
    public Vector2 size = new Vector2(4,0.5f);
    protected RectTransform rect;
    private Camera cam;
    protected virtual void Start()
    {
        cam = Camera.main;
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(size.x,size.y);
    }
    protected virtual void Update()
    {
        transform.position = cam.WorldToScreenPoint(targetObject.transform.position + offsetPos);
    }
}
