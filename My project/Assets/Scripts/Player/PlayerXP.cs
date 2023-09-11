using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] GameObject LevelUpMenu;
    private int XP;
    private int XPForLevel;
    private int playerLevel;

    void Start()
    {
        XP = 0;
        XPForLevel = 2;
        playerLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlayerXP(int amount){
        XP += amount;
        if(XP >= XPForLevel){
            XP = XPForLevel - XP;
            XPForLevel += 10;
            playerLevel += 1;
            LevelUp();
        }
    }

    public int getPlayerXP(){
        return XP;
    }
    public int getPlayerXPForLevel(){
        return XPForLevel;
    }

    private void LevelUp(){
        LevelUpMenu.SetActive(true);
    }
}
