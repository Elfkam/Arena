using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    IEnumerator SetActivePanel(){     
        SetDamagedColor();
        yield return new WaitForSeconds(1f);
        RemoveDamagedColor();
    }

    public void ShowDamageEffect(){        
        StartCoroutine(SetActivePanel());
    }
    private void SetDamagedColor(){
        GameObject.Find("ghost_head_1").GetComponent<SpriteRenderer>().material.color = new Color(174f/255f, 21f/255f, 21f/255f);
    }

    private void RemoveDamagedColor(){
        GameObject.Find("ghost_head_1").GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
    }
}
