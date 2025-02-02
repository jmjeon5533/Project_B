using UnityEngine;
using UnityEngine.UI;

public class UnitUI : TargetUI
{
    private Image image;
    [SerializeField] private Image icon;
    protected override void Start()
    {
        base.Start();
        image = GetComponent<Image>();
        icon.sprite = targetObject.icon;
    }
    protected override void Update()
    {
        base.Update();
        var ratio = Mathf.InverseLerp(0, targetObject.maxStamina, targetObject.curStamina);
        rect.sizeDelta = new Vector2(80 * ratio, 3f);
        image.color = ratio >= targetObject.needStaminaRatio ? Color.green : Color.yellow;
    }
}
