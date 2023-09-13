using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpellsData
{

    public class SpellInfo
    {
        public string SpellName { get; set; }
        public string SpellDescription { get; set; }
        public float CastTime { get; set; }
        public float TimeUntilCast { get; set; }
        public Action<Vector3> SpawnSpell { get; set; }
    }

    public static Dictionary<string, SpellInfo> GetDictionary(){
        Dictionary<string, SpellInfo> spells = new Dictionary<string, SpellInfo>
        {
            { "FireBall_1", new SpellInfo { SpellName = "FireBall_1", SpellDescription = "Popis FireBall_1", CastTime = 1.5f, TimeUntilCast = 1.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 5, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_2", new SpellInfo { SpellName = "FireBall_2", SpellDescription = "Popis FireBall_2", CastTime = 1.4f, TimeUntilCast = 1.4f,
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 10, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_3", new SpellInfo { SpellName = "FireBall_3", SpellDescription = "Popis FireBall_3", CastTime = 1.3f, TimeUntilCast = 1.3f,
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 15, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_4", new SpellInfo { SpellName = "FireBall_4", SpellDescription = "Popis FireBall_4", CastTime = 1f, TimeUntilCast = 1.2f,
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FireBall, PlayerAttacks.TypeSpellElement.Fire, 7f, GameAssets.i.FireBallExplosion, 20, PlayerAttacks.TypeSpellElement.Fire);} } },

            { "FrostBall_1", new SpellInfo { SpellName = "FrostBall_1", SpellDescription = "Popis FrostBall_1", CastTime = 1f, TimeUntilCast = 1f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 5, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_2", new SpellInfo { SpellName = "FrostBall_2", SpellDescription = "Popis FrostBall_2", CastTime = 0.9f, TimeUntilCast = 0.9f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 8, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_3", new SpellInfo { SpellName = "FrostBall_3", SpellDescription = "Popis FrostBall_3", CastTime = 0.7f, TimeUntilCast = 0.7f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 10, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_4", new SpellInfo { SpellName = "FrostBall_4", SpellDescription = "Popis FrostBall_4", CastTime = 0.5f, TimeUntilCast = 0.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 10, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },

            { "ChainLightning_1", new SpellInfo { SpellName = "ChainLightning_1", SpellDescription = "Popis ChainLightning_1", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 0, 10f);} } },
            { "ChainLightning_2", new SpellInfo { SpellName = "ChainLightning_2", SpellDescription = "Popis ChainLightning_2", CastTime = 1.8f, TimeUntilCast = 1.8f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 1, 10f);} } },
            { "ChainLightning_3", new SpellInfo { SpellName = "ChainLightning_3", SpellDescription = "Popis ChainLightning_3", CastTime = 1.6f, TimeUntilCast = 1.6f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 2, 10f);} } },
            { "ChainLightning_4", new SpellInfo { SpellName = "ChainLightning_4", SpellDescription = "Popis ChainLightning_4", CastTime = 1.5f, TimeUntilCast = 1.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 3, 20f);} } },
        };
        return spells;
    }


    public static List<string> GetDefaultSpells(){
        //List<string> defaultSpells = new List<string> {"FireBall_1", "FrostBall_1", "ChainLightning_1", "QuickHands_1", "FrostLighing_1", "GlassCannon_1", "Multicast_1"};
        List<string> defaultSpells = new List<string> {"FireBall_1", "FrostBall_1", "ChainLightning_1"};
        return defaultSpells;
    }



    public static SpellInfo GetSpellInfo(string key){
        return GetDictionary()[key];
    }
}
