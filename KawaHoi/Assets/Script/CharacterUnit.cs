using UnityEngine;

public class CharacterUnit : Unit
{
    protected override void Start()
    {
        StageManager.instance.AddCurUnit(this);
        UIManager.instance.SetUIObject(this.gameObject, UIManager.UIState.unit);
        base.Start();
    }
}
