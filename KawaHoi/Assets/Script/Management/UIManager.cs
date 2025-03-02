using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    public Transform ObjUIParent;
    public TargetUI[] UIObj;
    [Space(10)]
    [SerializeField] private Transform panelUIParent;
    [SerializeField] private UnitIconUI unitPanel;
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
        var ui = Instantiate(UIObj[(int)state], ObjUIParent).GetComponent<TargetUI>();
        ui.targetObject = snapObj;
    }
    public void AddUnitPanel(Unit unit)
    {
        var panel = Instantiate(unitPanel, panelUIParent);
        panel.targetUnit = unit;
    }
}
