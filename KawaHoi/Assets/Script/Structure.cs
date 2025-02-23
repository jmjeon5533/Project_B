using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
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
}
