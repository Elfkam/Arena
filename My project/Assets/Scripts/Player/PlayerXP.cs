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
            if(CheckIfPlayerCanLevelUp()) LevelUp();
        }
    }

    public int getPlayerXP(){
        return XP;
    }
    public int getPlayerXPForLevel(){
        return XPForLevel;
    }

    // TODO: replace with max level of player
    private bool CheckIfPlayerCanLevelUp(){
        List<string> spells = GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().GetAvailableSpells();
        if(spells.Count < 3) return false;
        return true;
    }

    private void SelectFirstSpell(){
        foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if(item == LevelUpMenu){
                item.GetComponent<LevelUpMenu>().SelectSpellStartMenu();
            }
        }
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
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
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
        Time.timeScale = 0; //pause game
    }
}
