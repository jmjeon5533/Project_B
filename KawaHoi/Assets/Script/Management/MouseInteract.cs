using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteract : MonoBehaviour
{
    RaycastHit hit;
    int layerMask;
    private void Start()
    {
        layerMask = LayerMask.GetMask("Environment", "Unit");
    }
    void Update()
    {
        var s = StageManager.instance;
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
                    case int _ when hitLayer == LayerMask.NameToLayer("Environment") && s.selectUnit != null:
                        // 환경을 클릭했을 때 이동
                        s.selectUnit = null;
                        break;
                    case int _ when hitLayer == LayerMask.NameToLayer("Unit"):
                        s.selectUnit = hitObject.GetComponent<Unit>();
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
                    case int _ when hitLayer == LayerMask.NameToLayer("Environment") && s.selectUnit != null:
                        // 환경을 클릭했을 때 이동
                        s.selectUnit.TargetMove(hit.point);
                        break;
                }

            }
        }
    }
}
