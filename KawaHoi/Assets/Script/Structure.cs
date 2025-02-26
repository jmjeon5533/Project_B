using System;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public event Action<List<Unit>> OnEnterUnitsChanged;

    public Sprite icon;
    public List<Unit> enterUnits = new List<Unit>();
    public enum StructState
    {
        myStruct,
        enemy,
        normal,
        random
    }
    public StructState state;
    void Start()
    {
        UIManager.instance.SetUIObject(this.gameObject, UIManager.UIState.structure);
    }
    public void AddUnit(Unit unit)
    {
        enterUnits.Add(unit);
        Debug.Log(enterUnits.Count);
        OnEnterUnitsChanged?.Invoke(enterUnits); // 이벤트 발생
    }

    public void RemoveUnit(Unit unit)
    {
        enterUnits.Remove(unit);
        Debug.Log(enterUnits.Count);
        OnEnterUnitsChanged?.Invoke(enterUnits); // 이벤트 발생
    }
}
