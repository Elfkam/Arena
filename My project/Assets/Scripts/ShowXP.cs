using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowXP : MonoBehaviour
{
    private PlayerXP playerXP;
    private TextMeshPro textMesh;
    void Start()
    {
        playerXP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerXP>();
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        setXP();
    }

    private void setXP(){
        textMesh.SetText(playerXP.getPlayerXP().ToString() + " / " + playerXP.getPlayerXPForLevel().ToString());
    }
}
