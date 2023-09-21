using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageDone : MonoBehaviour
{
    [SerializeField] private GameObject table;
    private Dictionary<string, int> dmgTable;
    private void Start()
    {
        dmgTable = new Dictionary<string, int>();
        List<string> keys = SpellsData.GetDefaultSpells();
        for (int i = 0; i < keys.Count; i++)
        {
            dmgTable.Add(keys[i].Substring(0, keys[i].Length - 2), 0);
        }
        AddRows();
    }

    public void AddRows(){
        foreach (var tableRow in dmgTable)
        {
            if(tableRow.Value == 0) continue;
            GameObject row = Instantiate(GameAssets.i.Row, transform.position, Quaternion.identity);            
            row.transform.SetParent(table.transform);
            row.transform.localScale = new Vector3(1,1,0);
            row.transform.localPosition = new Vector3(0,0,0);

            for (int j = 0; j < row.transform.childCount; j++)
            {
                switch(row.transform.GetChild(j).name){
                    case "Icon":
                        row.transform.GetChild(j).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + tableRow.Key);
                        break;
                    case "Spell":
                        row.transform.GetChild(j).GetComponent<TextMeshProUGUI>().text = tableRow.Key;
                        break;
                    case "DmgDone":
                        row.transform.GetChild(j).GetComponent<TextMeshProUGUI>().text = tableRow.Value.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void AddDamage(string spell, int damage){
        // replace prefabs name with they original prefab
        spell = spell == "BasicFireBall" ? "FireBall" : spell;
        spell = spell == "BasicFrostBall" ? "FrostBall" : spell;
        spell = spell == "FrostNovaExplosion" ? "FrostNova" : spell;
        spell = spell == "FireBallExplosion" ? "FireBall" : spell;
        dmgTable[spell] += damage;
    }
}
