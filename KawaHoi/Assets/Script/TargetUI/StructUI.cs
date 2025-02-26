using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructUI : TargetUI
{
    [SerializeField] private Image structImage;
    private Structure targetStructure;
    [SerializeField] Transform imageParent;
    [SerializeField] Image imagePrefab;
    [SerializeField] List<Image> enterImages = new List<Image>();
    protected override void Start()
    {
        targetStructure = targetObject.GetComponent<Structure>();
        targetStructure.OnEnterUnitsChanged += UpdateUI;
        base.Start();
        structImage.sprite = targetStructure.icon;
        for(int i = 0; i < 50; i++)
        {
            var newImg = Instantiate(imagePrefab,imageParent);
            newImg.gameObject.SetActive(false);
            enterImages.Add(newImg);
        }
    }
    void UpdateUI(List<Unit> units)
    {
        for (int i = 0; i < enterImages.Count; i++)
        {
            enterImages[i].gameObject.SetActive(i < units.Count);
        }
        for (int i = 0; i < units.Count; i++)
        {
            enterImages[i].sprite = units[i].icon;
        }
    }
}
