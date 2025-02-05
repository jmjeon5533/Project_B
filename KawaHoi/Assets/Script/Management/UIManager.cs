using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    public Transform canvas;
    public TargetUI[] UIObj;
    public enum UIState
    {
        unit,
        structure
    }
    private void Awake()
    {
        instance = this;
    }
    public void SetUIObject(GameObject snapObj, UIState state)
    {
        var ui = Instantiate(UIObj[(int)state], canvas).GetComponent<TargetUI>();
        ui.targetObject = snapObj;
    }
}
