using UnityEngine;
using UnityEngine.UI;

public class UnitStateUI : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [Space(10)]
    private Image icon;
    private Image HPBar;
    private Image staminaBar;
    private void Awake()
    {
        HPBar = Panel.transform.GetChild(0).GetComponent<Image>();
        staminaBar = Panel.transform.GetChild(1).GetComponent<Image>();
        icon = Panel.transform.GetChild(2).GetComponent<Image>();
    }
    public void ActiveSet(bool istrue, Unit unit = null)
    {
        var s = StageManager.instance;
        Panel.SetActive(istrue);
        if (!istrue) return;
        icon.sprite = s.selectUnit.icon;
        HPBar.fillAmount = s.selectUnit.curHP / s.selectUnit.maxHP;
        staminaBar.fillAmount = s.selectUnit.curStamina / s.selectUnit.maxStamina;
    }
    private void Update()
    {
        var s = StageManager.instance;
        ActiveSet(s.selectUnit != null,s.selectUnit);
    }
}
