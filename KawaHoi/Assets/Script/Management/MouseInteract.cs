using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteract : MonoBehaviour
{
    public Unit selectUnit;
    RaycastHit hit;
    void Update()
    {
        if (!StageManager.instance.isGame) return;
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, int.MaxValue, LayerMask.GetMask("Environment")))
            {
                print(hit.point);
                selectUnit.TargetMove(hit.point);
            }
        }
    }
}
