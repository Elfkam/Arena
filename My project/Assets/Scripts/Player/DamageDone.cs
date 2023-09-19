using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDone : MonoBehaviour
{
    [SerializeField]
    private GameObject table;
    private Dictionary<string, int> dmgTable;
    private void Start()
    {
        dmgTable = new Dictionary<string, int>();
        List<string> keys = SpellsData.GetDefaultSpells();
        for (int i = 0; i < keys.Count; i++)
        {
            dmgTable.Add(keys[i], 10);
        }
        AddRows();
    }

    public void AddRows(){
        for (int i = 0; i < dmgTable.Count; i++)
        {
            GameObject row = Instantiate(GameAssets.i.Row, transform.position, Quaternion.identity);
            
            row.transform.SetParent(table.transform);
            row.transform.localScale = new Vector3(1,1,0);
            // set icon
            //dmgTable[i].Key
            // set name
            // set dmg;
        }
    }

    public void AddDamage(string spell, int damage){
        dmgTable[spell] += damage;
    }
}
