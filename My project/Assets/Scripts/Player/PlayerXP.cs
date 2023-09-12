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
        XPForLevel = 1;
        playerLevel = 1;
        SelectFirstSpell();
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

    private void SelectFirstSpell(){
        foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if(item == LevelUpMenu){
                item.GetComponent<LevelUpMenu>().SelectSpellStartMenu();
            }
        }
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        Time.timeScale = 0; //pause game

    }
    private void LevelUp(){
        foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if(item == LevelUpMenu){
                item.GetComponent<LevelUpMenu>().LevelUpSetup();
            }
        }
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        Time.timeScale = 0; //pause game
    }
}
