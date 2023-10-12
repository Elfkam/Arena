using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    static int currDiffLevel;
    static int maxDiffLevel; // max diff player can play (based on progress)
    static int coins;
    static int playerCritChange;
    static int playerBonusHp;
    static int playerBonusDmg;
    static int playerBonusSpeed;
    static int playerCdReduction;

    // Static constructor is called at most one time, before any
    // instance constructor is invoked or member is accessed.
    static GameData(){
        maxDiffLevel = PlayerPrefs.GetInt("maxDiffLevel", 1);
        currDiffLevel = PlayerPrefs.GetInt("currDiffLevel", 1);
        playerCritChange = PlayerPrefs.GetInt("playerCritChange", 0);
        playerBonusHp = PlayerPrefs.GetInt("playerBonusHp", 0);
        playerBonusDmg = PlayerPrefs.GetInt("playerBonusDmg", 0);
        playerBonusSpeed = PlayerPrefs.GetInt("playerBonusSpeed", 0);
        playerCdReduction = PlayerPrefs.GetInt("playerCdReduction", 0);
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    public static void SetMaxDiffLevel(int level){
        PlayerPrefs.SetInt("maxDiffLevel", level);
        maxDiffLevel = level;
    }
    public static int GetMaxDiffLevel(){
        return maxDiffLevel;
    }


    public static void SetCurrDiffLevel(int level){
        PlayerPrefs.SetInt("currDiffLevel", level);
        currDiffLevel = level;
    }
    public static int GetCurrDiffLevel(){
        return currDiffLevel;
    }

    public static void SetPlayerCritChange(int critChange){
        PlayerPrefs.SetInt("playerCritChange", critChange);
        playerCritChange = critChange;
    }
    public static int GetPlayerCritChange(){
        return playerCritChange;
    }

    public static void SetPlayerBonusHp(int bonusHp){
        PlayerPrefs.SetInt("playerBonusHp", bonusHp);
        playerBonusHp = bonusHp;
    }
    public static int GetPlayerBonusHp(){
        return playerBonusHp;
    }

    public static void SetPlayerBonusDmg(int bonusDmg){
        PlayerPrefs.SetInt("playerBonusDmg", bonusDmg);
        playerBonusDmg = bonusDmg;
    }
    public static int GetPlayerBonusDmg(){
        return playerBonusDmg;
    }

    public static void SetPlayerBonusSpeed(int bonusSpeed){
        PlayerPrefs.SetInt("playerBonusSpeed", bonusSpeed);
        playerBonusSpeed = bonusSpeed;
    }
    public static int GetPlayerBonusSpeed(){
        return playerBonusSpeed;
    }
    
    public static void SetPlayerCdReduction(int cdReduction){
        PlayerPrefs.SetInt("playerCdReduction", cdReduction);
        playerCdReduction = cdReduction;
    }
    public static int GetPlayerCdReduction(){
        return playerCdReduction;
    }

    public static void SetCoins(int coinsArg){
        PlayerPrefs.SetInt("coins", coinsArg);
        coins = coinsArg;
    }
    public static int GetCoins(){
        return coins;
    }    
    public static void Set(string name, int value){
        switch(name){
            case "playerCritChange":
                GameData.SetPlayerCritChange(value);
                break;
            case "playerBonusHp":
                GameData.SetPlayerBonusHp(value);
                break;
            case "playerBonusDmg":
                GameData.SetPlayerBonusDmg(value);
                break;
            case "playerBonusSpeed":
                GameData.SetPlayerBonusSpeed(value);
                break;
            case "playerCdReduction":
                GameData.SetPlayerCdReduction(value);
                break;
            default:
                break;
        }
    }

    public static int Get(string name){
        switch(name){
            case "playerCritChange":
                return GameData.GetPlayerCritChange();
            case "playerBonusHp":
                return GameData.GetPlayerBonusHp();
            case "playerBonusDmg":
                return GameData.GetPlayerBonusDmg();
            case "playerBonusSpeed":
                return GameData.GetPlayerBonusSpeed();
            case "playerCdReduction":
                return GameData.GetPlayerCdReduction();
            default:
                return 0;
        }
    }

    public static int GetMaxValue(string name){
        switch(name){
            case "playerCritChange":
                return 50;
            case "playerBonusHp":
                return 100;
            case "playerBonusDmg":
                return 100;
            case "playerBonusSpeed":
                return 50;
            case "playerCdReduction":
                return 50;
            default:
                return 0;
        }
    }

    public static void ResetPoints(){
        int addCoins = GetPlayerBonusDmg() + GetPlayerBonusHp() + GetPlayerBonusSpeed() + GetPlayerCdReduction() + GetPlayerCritChange();
        SetPlayerBonusDmg(0);
        SetPlayerBonusHp(0);
        SetPlayerBonusSpeed(0);
        SetPlayerCdReduction(0);
        SetPlayerCritChange(0);
        SetCoins(GetCoins() + addCoins);
    }
}
