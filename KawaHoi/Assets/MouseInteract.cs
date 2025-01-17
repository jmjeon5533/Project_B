using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, int.MaxValue, LayerMask.GetMask("Environment")))
            {
                print("Interact");
            }
        }
    }
}
