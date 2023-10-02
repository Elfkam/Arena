using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] LevelUpMenu levelUpMenu;
    [SerializeField] private ShowXP xpBar;
    private int XP;
    private int XPForLevel;
    private int playerLevel;

    void Start()
    {
        XP = 0;
        XPForLevel = 5;
        playerLevel = 1;
        SelectFirstSpell();
        xpBar.SetMaxXP(XPForLevel);
    }
    public void setPlayerXP(int amount){
        XP += amount;
        xpBar.SetXP(XP);
        if(XP >= XPForLevel){
            XP = XPForLevel - XP;
            XPForLevel += 5;
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

    public int GetPlayerLevel(){
        return playerLevel;
    }

    // TODO: replace with max level of player
    private bool CheckIfPlayerCanLevelUp(){
        List<string> spells = GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().GetAvailableSpells();
        if(spells.Count < 3) return false;
        return true;
    }

    private void SelectFirstSpell(){
        levelUpMenu.SelectSpellStartMenu();
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
        Time.timeScale = 0; //pause game

    }
    private void LevelUp(){
        xpBar.SetMaxXP(XPForLevel);
        FindAnyObjectByType<AudioManager>().Play("LevelUp");
        levelUpMenu.LevelUpSetup();
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
        Time.timeScale = 0; //pause game
    }
}
