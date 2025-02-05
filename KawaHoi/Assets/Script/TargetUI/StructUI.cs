using UnityEngine;
using UnityEngine.UI;

public class StructUI : TargetUI
{
    private Image image;
    private Structure targetStructure;
    [SerializeField] private Image icon;
    protected override void Start()
    {
        targetStructure = targetObject.GetComponent<Structure>();
        base.Start();
        image = GetComponent<Image>();
        icon.sprite = targetStructure.icon;
    }
}
