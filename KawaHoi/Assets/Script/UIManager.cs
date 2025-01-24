using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    public Transform canvas;
    public TargetUI staminaUIObj;
    private void Awake()
    {
        instance = this;
    }
    public void SetUIObject(Unit snapObj)
    {
        var ui = Instantiate(staminaUIObj, canvas).GetComponent<TargetUI>();
        ui.targetObject = snapObj;
    }
}
