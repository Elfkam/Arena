using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowXP : MonoBehaviour
{
    private PlayerXP playerXP;
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        playerXP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerXP>();
        textMesh = transform.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        setXP();
    }

    private void setXP(){
        textMesh.SetText(playerXP.getPlayerXP().ToString() + " / " + playerXP.getPlayerXPForLevel().ToString());
    }
}
