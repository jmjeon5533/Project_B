using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : TargetUI
{
    Image image;
    protected override void Start()
    {
        base.Start();
        image = GetComponent<Image>();
    }
    protected override void Update()
    {
        base.Update();
        var ratio = targetObject.curStamina / targetObject.maxStamina;
        rect.sizeDelta = new Vector2(4 * Mathf.Lerp(0,targetObject.maxStamina,
            ratio), 0.5f);
        image.color = ratio >= targetObject.needStaminaRatio ? Color.green : Color.yellow;
    }
}
