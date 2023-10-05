using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    static int diffLevel = 1;

    public static void SetDiffLevel(int level){
        diffLevel = level;
    }

    public static int GetDiffLevel(){
        return diffLevel;
    }
    
}
