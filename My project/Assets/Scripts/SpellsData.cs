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
            { "FireBall_1", new SpellInfo { SpellName = "FireBall_1", SpellDescription = "Popis FireBall_1", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 5, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_2", new SpellInfo { SpellName = "FireBall_2", SpellDescription = "Popis FireBall_2", CastTime = 1.5f, TimeUntilCast = 1.5f,
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 8, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_3", new SpellInfo { SpellName = "FireBall_3", SpellDescription = "Popis FireBall_3", CastTime = 1f, TimeUntilCast = 1f,
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 10, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_4", new SpellInfo { SpellName = "FireBall_4", SpellDescription = "Popis FireBall_4", CastTime = 1f, TimeUntilCast = 1f,
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FireBall, PlayerAttacks.TypeSpellElement.Fire, 7f, GameAssets.i.FireBallExplosion, 10, PlayerAttacks.TypeSpellElement.Fire);} } },

            { "FrostBall_1", new SpellInfo { SpellName = "FrostBall_1", SpellDescription = "Popis FrostBall_1", CastTime = 1.5f, TimeUntilCast = 1.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 5, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_2", new SpellInfo { SpellName = "FrostBall_2", SpellDescription = "Popis FrostBall_2", CastTime = 1f, TimeUntilCast = 1f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 5, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_3", new SpellInfo { SpellName = "FrostBall_3", SpellDescription = "Popis FrostBall_3", CastTime = 0.8f, TimeUntilCast = 0.8f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 8, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_4", new SpellInfo { SpellName = "FrostBall_4", SpellDescription = "Popis FrostBall_4", CastTime = 0.5f, TimeUntilCast = 0.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 10, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },

            { "ChainLightning_1", new SpellInfo { SpellName = "ChainLightning_1", SpellDescription = "Popis ChainLightning_1", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 1, 10f);} } },
            { "ChainLightning_2", new SpellInfo { SpellName = "ChainLightning_2", SpellDescription = "Popis ChainLightning_2", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 2, 10f);} } },
            { "ChainLightning_3", new SpellInfo { SpellName = "ChainLightning_3", SpellDescription = "Popis ChainLightning_3", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 3, 10f);} } },
            { "ChainLightning_4", new SpellInfo { SpellName = "ChainLightning_4", SpellDescription = "Popis ChainLightning_4", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 5, 10f);} } },

            { "WindBlast_1", new SpellInfo { SpellName = "WindBlast_1", SpellDescription = "Popis WindBlast_1", CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 5, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },
            { "WindBlast_2", new SpellInfo { SpellName = "WindBlast_2", SpellDescription = "Popis WindBlast_2", CastTime = 2.5f, TimeUntilCast =2.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 7, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },
            { "WindBlast_3", new SpellInfo { SpellName = "WindBlast_3", SpellDescription = "Popis WindBlast_3", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 7, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },
            { "WindBlast_4", new SpellInfo { SpellName = "WindBlast_4", SpellDescription = "Popis WindBlast_4", CastTime = 1f, TimeUntilCast = 1f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 10, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },

            { "Tornado_1", new SpellInfo { SpellName = "Tornado_1", SpellDescription = "Popis Tornado_1", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 3, PlayerAttacks.TypeSpellElement.Wind, 3f, 3f);} } },
            { "Tornado_2", new SpellInfo { SpellName = "Tornado_2", SpellDescription = "Popis Tornado_2", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 5, PlayerAttacks.TypeSpellElement.Wind, 4f, 3f);} } },
            { "Tornado_3", new SpellInfo { SpellName = "Tornado_3", SpellDescription = "Popis Tornado_3", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 5, PlayerAttacks.TypeSpellElement.Wind, 5f, 3f);} } },
            { "Tornado_4", new SpellInfo { SpellName = "Tornado_4", SpellDescription = "Popis Tornado_4", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 10, PlayerAttacks.TypeSpellElement.Wind, 10f, 3f);} } },

            { "FrostNova_1", new SpellInfo { SpellName = "FrostNova_1", SpellDescription = "Popis FrostNova_1", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 2, PlayerAttacks.TypeSpellElement.Frost);} } },
            { "FrostNova_2", new SpellInfo { SpellName = "FrostNova_2", SpellDescription = "Popis FrostNova_2", CastTime = 4f, TimeUntilCast = 4f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 5, PlayerAttacks.TypeSpellElement.Frost);} } },
            { "FrostNova_3", new SpellInfo { SpellName = "FrostNova_3", SpellDescription = "Popis FrostNova_3", CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 5, PlayerAttacks.TypeSpellElement.Frost);} } },
            { "FrostNova_4", new SpellInfo { SpellName = "FrostNova_4", SpellDescription = "Popis FrostNova_4", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 10, PlayerAttacks.TypeSpellElement.Frost);} } },

            { "LightningBolt_1", new SpellInfo { SpellName = "LightningBolt_1", SpellDescription = "Popis LightningBolt_1", CastTime = 4f, TimeUntilCast = 4f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 10, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },
            { "LightningBolt_2", new SpellInfo { SpellName = "LightningBolt_2", SpellDescription = "Popis LightningBolt_2", CastTime = 3.5f, TimeUntilCast = 3.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 10, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },
            { "LightningBolt_3", new SpellInfo { SpellName = "LightningBolt_3", SpellDescription = "Popis LightningBolt_3", CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 10, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },
            { "LightningBolt_4", new SpellInfo { SpellName = "LightningBolt_4", SpellDescription = "Popis LightningBolt_4", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 10, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },

            { "PyroBlast_1", new SpellInfo { SpellName = "PyroBlast_1", SpellDescription = "Popis PyroBlast_1", CastTime = 4f, TimeUntilCast = 4f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 10, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },
            { "PyroBlast_2", new SpellInfo { SpellName = "PyroBlast_2", SpellDescription = "Popis PyroBlast_2", CastTime = 3.5f, TimeUntilCast = 3.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 12, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },
            { "PyroBlast_3", new SpellInfo { SpellName = "PyroBlast_3", SpellDescription = "Popis PyroBlast_3", CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 15, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },
            { "PyroBlast_4", new SpellInfo { SpellName = "PyroBlast_4", SpellDescription = "Popis PyroBlast_4", CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 15, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },

            { "FrostRing_1", new SpellInfo { SpellName = "FrostRing_1", SpellDescription = "Popis FrostRing_1", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 5, PlayerAttacks.TypeSpellElement.Frost, 3f, 3f);} } },
            { "FrostRing_2", new SpellInfo { SpellName = "FrostRing_2", SpellDescription = "Popis FrostRing_2", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 7, PlayerAttacks.TypeSpellElement.Frost, 4f, 3f);} } },
            { "FrostRing_3", new SpellInfo { SpellName = "FrostRing_3", SpellDescription = "Popis FrostRing_3", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 8, PlayerAttacks.TypeSpellElement.Frost, 5f, 3f);} } },
            { "FrostRing_4", new SpellInfo { SpellName = "FrostRing_4", SpellDescription = "Popis FrostRing_4", CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 10, PlayerAttacks.TypeSpellElement.Frost, 10f, 3f);} } },

            { "FrostOrb_1", new SpellInfo { SpellName = "FrostOrb_1", SpellDescription = "Popis FrostOrb_1", CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 5, PlayerAttacks.TypeSpellElement.Frost, 2f, 2f);} } },
            { "FrostOrb_2", new SpellInfo { SpellName = "FrostOrb_2", SpellDescription = "Popis FrostOrb_2", CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 7, PlayerAttacks.TypeSpellElement.Frost, 2f, 3f);} } },
            { "FrostOrb_3", new SpellInfo { SpellName = "FrostOrb_3", SpellDescription = "Popis FrostOrb_3", CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 8, PlayerAttacks.TypeSpellElement.Frost, 2f, 4f);} } },
            { "FrostOrb_4", new SpellInfo { SpellName = "FrostOrb_4", SpellDescription = "Popis FrostOrb_4", CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 10, PlayerAttacks.TypeSpellElement.Frost, 2f, 5f);} } },

            { "LightningOrb_1", new SpellInfo { SpellName = "LightningOrb_1", SpellDescription = "Popis LightningOrb_1", CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 7, PlayerAttacks.TypeSpellElement.Lightning, 2f, 2f);} } },
            { "LightningOrb_2", new SpellInfo { SpellName = "LightningOrb_2", SpellDescription = "Popis LightningOrb_2", CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 9, PlayerAttacks.TypeSpellElement.Lightning, 2f, 3f);} } },
            { "LightningOrb_3", new SpellInfo { SpellName = "LightningOrb_3", SpellDescription = "Popis LightningOrb_3", CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 10, PlayerAttacks.TypeSpellElement.Lightning, 2f, 4f);} } },
            { "LightningOrb_4", new SpellInfo { SpellName = "LightningOrb_4", SpellDescription = "Popis LightningOrb_4", CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 12, PlayerAttacks.TypeSpellElement.Lightning, 2f, 5f);} } },
 

        };
        return spells;
    }


    public static List<string> GetDefaultSpells(){
       /*  List<string> defaultSpells = new List<string> {"FireBall_1", "FrostBall_1", "ChainLightning_1", "WindBlast_1", "Tornado_1", "FrostNova_1", "LightningBolt_1", 
        "PyroBlast_1", "FrostRing_1", "FrostOrb_1", "LightningOrb_1"}; */
        List<string> defaultSpells = new List<string> {"WindBlast_1","Tornado_1","FireBall_1", "FrostBall_1", "ChainLightning_1", "WindBlast_1"};

        return defaultSpells;
    }



    public static SpellInfo GetSpellInfo(string key){
        return GetDictionary()[key];
    }
}
