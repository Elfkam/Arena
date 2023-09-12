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
    public void setPlayerXP(int amount){
        XP += amount;
        if(XP >= XPForLevel){
            XP = XPForLevel - XP;
            XPForLevel += 1;
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
        foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if(item == LevelUpMenu){
                item.GetComponent<LevelUpMenu>().LevelUpSetup();
            }
        }
        //GameObject.Find("GameHandler/UI/LevelUpMenu").SetActive(true);
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        Time.timeScale = 0; //pause game
    }
}
