using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitIconUI : MonoBehaviour, IPointerClickHandler
{
    public Unit targetUnit;
    [SerializeField] Image icon;
    void Start()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
        icon.sprite = targetUnit.icon;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StageManager.instance.selectUnit = targetUnit;
    }
}
