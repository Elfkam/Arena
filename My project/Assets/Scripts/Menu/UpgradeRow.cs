using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeRow : MonoBehaviour
{
    private string iconName;
    private int value;
    private Button btn;
    private void Start()
    {
        btn = gameObject.transform.GetChild(3).GetComponent<Button>();
    }
    private void Update()
    {
        CheckButton(btn);
    }
    public static UpgradeRow Create(Vector3 position, GameObject parent, GameObject gm, string iconName, int value, string description){
        Transform rowTransform = Instantiate(gm, position, Quaternion.identity).transform;
        UpgradeRow row = rowTransform.GetComponent<UpgradeRow>();
        row.Setup(iconName, value, description);

        row.transform.SetParent(parent.transform);
        row.transform.localScale = new Vector3(1,1,0);
        row.transform.localPosition = new Vector3(0,0,0);
        return row;
    }

    private void Setup(string iconName, int value, string description){
        this.iconName = iconName;
        this.value = value;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            switch(child.name){
                case "Icon":
                    child.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Upgrades/" + iconName);
                    continue;
                case "Text":
                    child.GetComponent<TextMeshProUGUI>().text = description;                    
                    continue;
                case "Add":
                    child.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("Canvas/UpgradesMenu").GetComponent<UpgradesMenu>().SelectUpgrade());
                    CheckButton(child.GetComponent<Button>());       
                    continue;
                default:
                    continue;
            }
        }
    }

    private void CheckButton(Button btn){
        if(GameData.GetCoins() <= 0 || GameData.Get(iconName) >= GameData.GetMaxValue(iconName)){
            btn.interactable = false; 
        }else{
            btn.interactable = true;;
        }         
    }
}
