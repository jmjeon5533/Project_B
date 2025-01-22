using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public Unit selectUnit;
    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, int.MaxValue, LayerMask.GetMask("Environment")))
            {
                print("Interact");
                selectUnit.TargetMove(hit.point);
            }
        }
    }
}
