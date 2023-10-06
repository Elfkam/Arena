using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{
    private List<string> upgrades;
    [SerializeField] private GameObject tableContent;
    [SerializeField] private TextMeshProUGUI text;
    public void SetActive(){
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
        gameObject.SetActive(true);
    }

    private void Update()
    {
        text.text = GameData.GetCoins().ToString();
    }

    public void SelectUpgrade(){
        GameObject parent = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;

        string IconName = "";

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            switch(child.name){
                case "Icon":
                    IconName = child.GetComponent<Image>().sprite.name;
                    continue;
                case "Text":
                    child.GetComponent<TextMeshProUGUI>().text = GetDescription(IconName, GameData.Get(IconName) + 1);                   
                    continue;
                default:
                    continue;
            }
        }        
        GameData.Set(IconName, GameData.Get(IconName) + 1);
        GameData.SetCoins(GameData.GetCoins() -1);

    }

    private void AddRow(string name){
        switch(name){
            case "playerCritChange":
                UpgradeRow.Create(gameObject.transform.position, tableContent, GameAssets.i.UpgradeRow, "playerCritChange", GameData.GetPlayerCritChange(), GetDescription("playerCritChange", GameData.GetPlayerCritChange()));
                break;
            case "playerBonusHp":
                UpgradeRow.Create(gameObject.transform.position, tableContent, GameAssets.i.UpgradeRow, "playerBonusHp", GameData.GetPlayerBonusHp(), GetDescription("playerBonusHp", GameData.GetPlayerBonusHp()));
                break;
            case "playerBonusDmg":
                UpgradeRow.Create(gameObject.transform.position, tableContent, GameAssets.i.UpgradeRow, "playerBonusDmg", GameData.GetPlayerBonusDmg(), GetDescription("playerBonusDmg", GameData.GetPlayerBonusDmg()));
                break;
            case "playerBonusSpeed":
                UpgradeRow.Create(gameObject.transform.position, tableContent, GameAssets.i.UpgradeRow, "playerBonusSpeed", GameData.GetPlayerBonusSpeed(), GetDescription("playerBonusSpeed", GameData.GetPlayerBonusSpeed()));
                break;
            case "playerCdReduction":
                UpgradeRow.Create(gameObject.transform.position, tableContent, GameAssets.i.UpgradeRow, "playerCdReduction", GameData.GetPlayerCdReduction(), GetDescription("playerCdReduction", GameData.GetPlayerCdReduction()));
                break;
            default:
                break;
        }
    }
    
    private string GetDescription(string name, int value){
        switch(name){
            case "playerCritChange":                
                return "<color=\"green\">" + value + " / " + GameData.GetMaxValue(name) + "</color>\n\nIncrease critical change of all spells";
            case "playerBonusHp":                
                return "<color=\"green\">" + value + " / " + GameData.GetMaxValue(name) + "</color>\n\nIncrease player health";
            case "playerBonusDmg":
                return "<color=\"green\">" + value + " / " + GameData.GetMaxValue(name) + "</color>\n\nIncrease damage of all spells";
            case "playerBonusSpeed":
                return "<color=\"green\">" + value + " / " + GameData.GetMaxValue(name) + "</color>\n\nIncrease player movement speed";
            case "playerCdReduction":
                return "<color=\"green\">" + value + " / " + GameData.GetMaxValue(name) + "</color>\n\nIncrease casting speed of all spells";
            default:
                return "";
        }
    }

    public void GetFreeCoins(){
        // TODO: watch ad
        GameData.SetCoins(GameData.GetCoins() + 5);
    }

    public void ResetPoints(){
        // TODO: watch ad
        GameData.ResetPoints();
        for (int i = 0; i < tableContent.transform.childCount; i++)
        {
            GameObject row = tableContent.transform.GetChild(i).gameObject;
            string IconName = row.transform.GetChild(1).GetComponent<Image>().sprite.name;
            row.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GetDescription(IconName, 0);
        }
    }
}
