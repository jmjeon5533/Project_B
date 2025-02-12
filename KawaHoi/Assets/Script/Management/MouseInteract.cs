using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteract : MonoBehaviour
{
    public Unit selectUnit;
    RaycastHit hit;
    int layerMask;
    private void Start()
    {
        layerMask = LayerMask.GetMask("Environment", "Unit");
    }
    void Update()
    {
        if (!StageManager.instance.isGame) return;
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, int.MaxValue, layerMask))
            {
                GameObject hitObject = hit.collider.gameObject;
                int hitLayer = hitObject.layer;

                switch (hitLayer)
                {
                    case int _ when hitLayer == LayerMask.NameToLayer("Environment") && selectUnit != null:
                        // 환경을 클릭했을 때 이동
                        selectUnit = null;
                        break;
                    case int _ when hitLayer == LayerMask.NameToLayer("Unit"):
                        selectUnit = hitObject.GetComponent<Unit>();
                        break;
                }
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, int.MaxValue, layerMask))
            {
                GameObject hitObject = hit.collider.gameObject;
                int hitLayer = hitObject.layer;

                switch (hitLayer)
                {
                    case int _ when hitLayer == LayerMask.NameToLayer("Environment") && selectUnit != null:
                        // 환경을 클릭했을 때 이동
                        selectUnit.TargetMove(hit.point);
                        break;
                }

            }
        }
    }
}
