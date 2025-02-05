using UnityEngine;

public class Structure : MonoBehaviour
{
    public Sprite icon;
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
