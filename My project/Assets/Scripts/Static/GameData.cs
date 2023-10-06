using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    static int diffLevel;
    static int coins;
    static float playerCritChange;
    static int playerBonusHp;
    static int playerBonusDmg;
    static float playerBonusSpeed;
    static float playerCdReduction;

    // Static constructor is called at most one time, before any
    // instance constructor is invoked or member is accessed.
    static GameData(){
        diffLevel = PlayerPrefs.GetInt("diffLevel", 1);
        playerCritChange = PlayerPrefs.GetInt("playerCritChange", 0);
        playerBonusHp = PlayerPrefs.GetInt("playerBonusHp", 0);
        playerBonusDmg = PlayerPrefs.GetInt("playerBonusDmg", 0);
        playerBonusSpeed = PlayerPrefs.GetInt("playerBonusSpeed", 0);
        playerCdReduction = PlayerPrefs.GetInt("playerCdReduction", 0);
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    public static void SetDiffLevel(int level){
        PlayerPrefs.SetInt("diffLevel", level);
        diffLevel = level;
    }
    public static int GetDiffLevel(){
        return diffLevel;
    }

    public static void SetPlayerCritChange(float critChange){
        PlayerPrefs.SetFloat("playerCritChange", critChange);
        playerCritChange = critChange;
    }
    public static float GetPlayerCritChange(){
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

    public static void SetPlayerBonusSpeed(float bonusSpeed){
        PlayerPrefs.SetFloat("playerBonusSpeed", bonusSpeed);
        playerBonusSpeed = bonusSpeed;
    }
    public static float GetPlayerBonusSpeed(){
        return playerBonusSpeed;
    }
    
    public static void SetPlayerCdReduction(float cdReduction){
        PlayerPrefs.SetFloat("playerCdReduction", cdReduction);
        playerCdReduction = cdReduction;
    }
    public static float GetPlayerCdReduction(){
        return playerCdReduction;
    }

    public static void SetCoins(int coinsArg){
        PlayerPrefs.SetFloat("coins", coinsArg);
        coins = coinsArg;
    }
    public static int GetCoins(){
        return coins;
    }
}
