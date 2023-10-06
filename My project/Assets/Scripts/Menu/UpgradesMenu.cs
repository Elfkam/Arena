using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{
    private List<string> upgrades;
    [SerializeField] private GameObject tableContent;
    private void Start()
    {
        upgrades = new List<string>{
            {"playerCritChange"},
            {"playerBonusHp"},
            {"playerBonusDmg"},
            {"playerBonusSpeed"},
            {"playerCdReduction"},
        };
        foreach (string row in upgrades)
        {
            AddRow(row);
        }
    }

    public void SelectUpgrade(){
        if(GameData.GetCoins() <= 0) return;
        GameObject parent = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;

        string IconName = "";
        GameObject Text = new GameObject("");

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            switch(child.name){
                case "Icon":
                    IconName = child.GetComponent<Image>().sprite.name;
                    continue;
                case "Text":
                    Text = child;                    
                    continue;
                default:
                    continue;
            }
        }
        Text.GetComponent<TextMeshProUGUI>().text = GetDescription(IconName, Get(IconName) + 1); 
        Set(IconName, Get(IconName) + 1);
        GameData.SetCoins(GameData.GetCoins() -1);

    }

    private void AddRow(string name){
        GameObject row = new GameObject("");
        switch(name){
            case "playerCritChange":
                row = UpgradeRow.Create(gameObject.transform.position, GameAssets.i.UpgradeRow, "playerCritChange", GameData.GetPlayerCritChange(), GetDescription("playerCritChange", GameData.GetPlayerCritChange())).gameObject;
                break;
            case "playerBonusHp":
                row = UpgradeRow.Create(gameObject.transform.position, GameAssets.i.UpgradeRow, "playerBonusHp", GameData.GetPlayerBonusHp(), GetDescription("playerBonusHp", GameData.GetPlayerBonusHp())).gameObject;
                break;
            case "playerBonusDmg":
                row = UpgradeRow.Create(gameObject.transform.position, GameAssets.i.UpgradeRow, "playerBonusDmg", GameData.GetPlayerBonusDmg(), GetDescription("playerBonusDmg", GameData.GetPlayerBonusDmg())).gameObject;
                break;
            case "playerBonusSpeed":
                row = UpgradeRow.Create(gameObject.transform.position, GameAssets.i.UpgradeRow, "playerBonusSpeed", GameData.GetPlayerBonusSpeed(), GetDescription("playerBonusSpeed", GameData.GetPlayerBonusSpeed())).gameObject;
                break;
            case "playerCdReduction":
                row = UpgradeRow.Create(gameObject.transform.position, GameAssets.i.UpgradeRow, "playerCdReduction", GameData.GetPlayerCdReduction(), GetDescription("playerCdReduction", GameData.GetPlayerCdReduction())).gameObject;
                break;
            default:
                break;
        }
        row.transform.SetParent(tableContent.transform);
        row.transform.localScale = new Vector3(1,1,0);
        row.transform.localPosition = new Vector3(0,0,0);
    }
    
    private string GetDescription(string name, int value){
        switch(name){
            case "playerCritChange":                
                return "<color=\"green\">" + value + " / 50</color>\n\nIncrease crit change of all spells";
            case "playerBonusHp":                
                return "<color=\"green\">" + value + " / 50</color>\n\nIncrease player health";
            case "playerBonusDmg":
                return "<color=\"green\">" + value + " / 50</color>\n\nIncrease damage of all spells";
            case "playerBonusSpeed":
                return "<color=\"green\">" + value + " / 50</color>\n\nIncrease player movement speed";
            case "playerCdReduction":
                return "<color=\"green\">" + value + " / 50</color>\n\nIncrease casting speed of all spells";
            default:
                return "";
        }
    }

    private void Set(string name, int value){
        switch(name){
            case "playerCritChange":
                GameData.SetPlayerCritChange(value);
                break;
            case "playerBonusHp":
                GameData.SetPlayerBonusHp(value);
                break;
            case "playerBonusDmg":
                GameData.SetPlayerBonusDmg(value);
                break;
            case "playerBonusSpeed":
                GameData.SetPlayerBonusSpeed(value);
                break;
            case "playerCdReduction":
                GameData.SetPlayerCdReduction(value);
                break;
            default:
                break;
        }
    }

    private int Get(string name){
        switch(name){
            case "playerCritChange":
                return GameData.GetPlayerCritChange();
            case "playerBonusHp":
                return GameData.GetPlayerBonusHp();
            case "playerBonusDmg":
                return GameData.GetPlayerBonusDmg();
            case "playerBonusSpeed":
                return GameData.GetPlayerBonusSpeed();
            case "playerCdReduction":
                return GameData.GetPlayerCdReduction();
            default:
                return 0;
        }
    }

}
