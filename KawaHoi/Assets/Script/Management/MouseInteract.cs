using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteract : MonoBehaviour
{
    RaycastHit hit;
    int layerMask;
    private void Start()
    {
        layerMask = LayerMask.GetMask("Environment", "Unit", "Structure");
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
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 2f);

            if (Physics.Raycast(ray, out hit, int.MaxValue, layerMask))
            {
                GameObject hitObject = hit.collider.gameObject;
                int hitLayer = hitObject.layer;
                var select = s.selectUnit;

                switch (hitLayer)
                {
                    case int _ when hitLayer == LayerMask.NameToLayer("Environment") && select != null:
                        if (select.isEnterStructure)
                        {
                            select.isEnterStructure = false;
                            select.structTarget.enterUnits.Remove(select);
                            select.gameObject.SetActive(true);
                            select.unitUI.gameObject.SetActive(true);
                            select.structTarget = null;
                        }
                        select.TargetMove(hit.point);
                        print("environment");
                        break;
                    case int _ when hitLayer == LayerMask.NameToLayer("Structure") && select != null:
                        print("Struct");
                        select.structTarget = hitObject.GetComponent<Structure>();
                        select.TargetMove(hit.point);
                        break;

                }

            }
        }
        
    }
}
