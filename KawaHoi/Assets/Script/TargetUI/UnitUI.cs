using UnityEngine;
using UnityEngine.UI;

public class UnitUI : TargetUI
{
    private Image image;
    private Unit targetUnit;
    [SerializeField] private Image icon;
    protected override void Start()
    {
        targetUnit = targetObject.GetComponent<Unit>();
        base.Start();
        image = GetComponent<Image>();
        icon.sprite = targetUnit.icon;
    }
    protected override void Update()
    {
        base.Update();
        var ratio = Mathf.InverseLerp(0, targetUnit.maxStamina, targetUnit.curStamina);
        rect.sizeDelta = new Vector2(80 * ratio, 3f);
        image.color = ratio >= targetUnit.needStaminaRatio ? Color.green : Color.yellow;
    }
}
