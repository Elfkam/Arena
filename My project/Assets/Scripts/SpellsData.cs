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
            { "FireBall_1", new SpellInfo { SpellName = "FireBall_1", 
            SpellDescription = "<b>Fireball lv 1</b>\n\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage.</size>", 
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 5, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_2", new SpellInfo { SpellName = "FireBall_2", 
            SpellDescription = "<b>Fireball lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage.\n<color=\"green\">damage + 3\ncooldown -25%</color></size>", 
            CastTime = 1.5f, TimeUntilCast = 1.5f,
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 8, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_3", new SpellInfo { SpellName = "FireBall_3", 
            SpellDescription = "<b>Fireball lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage.\n<color=\"green\">damage + 2\ncooldown -25%</color></size>", 
            CastTime = 1f, TimeUntilCast = 1f,
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFireBall, 10, PlayerAttacks.TypeSpellElement.Fire, 5f);} } },
            { "FireBall_4", new SpellInfo { SpellName = "FireBall_4", 
            SpellDescription = "<b>Fireball lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage.\n<color=\"green\">speed + 50%\n<b>explodes on inpact</b></color></size>", 
            CastTime = 1f, TimeUntilCast = 1f,
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FireBall, PlayerAttacks.TypeSpellElement.Fire, 7.5f, GameAssets.i.FireBallExplosion, 10, PlayerAttacks.TypeSpellElement.Fire);} } },

            { "FrostBall_1", new SpellInfo { SpellName = "FrostBall_1", 
            SpellDescription = "<b>Frostball lv 1</b>\n\n<size=70%>Fire a projectile at an enemy that deals <color=#1F91A9>FROST</color> damage.</size>", 
            CastTime = 1.5f, TimeUntilCast = 1.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 5, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_2", new SpellInfo { SpellName = "FrostBall_2", 
            SpellDescription = "<b>Frostball lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=#1F91A9>FROST</color> damage.\n<color=\"green\">cooldown -33%</color></size>", 
            CastTime = 1f, TimeUntilCast = 1f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 5, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_3", new SpellInfo { SpellName = "FrostBall_3", 
            SpellDescription = "<b>Frostball lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=#1F91A9>FROST</color> damage.\n<color=\"green\">damage + 3\ncooldown -20%</color></size>", 
            CastTime = 0.8f, TimeUntilCast = 0.8f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 8, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },
            { "FrostBall_4", new SpellInfo { SpellName = "FrostBall_4", 
            SpellDescription = "<b>Frostball lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=#1F91A9>FROST</color> damage.\n<color=\"green\">damage + 2\ncooldown -33%</color></size>", 
            CastTime = 0.5f, TimeUntilCast = 0.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerBasicAttack.Create(pos, GameAssets.i.BasicFrostBall, 10, PlayerAttacks.TypeSpellElement.Frost, 5f);} } },

            { "ChainLightning_1", new SpellInfo { SpellName = "ChainLightning_1", 
            SpellDescription = "<b>Chain Lightning lv 1 </b>\n\n<size=70%>Hurls a lightning bolt at the enemy that deals <color=\"purple\">LIGHTNING</color> damage and then jumps to additional enemies.</size>", 
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 1, 10f);} } },
            { "ChainLightning_2", new SpellInfo { SpellName = "ChainLightning_2", 
            SpellDescription = "<b>Chain Lightning lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Hurls a lightning bolt at the enemy that deals <color=\"purple\">LIGHTNING</color> damage and then jumps to additional enemies.\n<color=\"green\">additional jump + 1</color></size>", 
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 2, 10f);} } },
            { "ChainLightning_3", new SpellInfo { SpellName = "ChainLightning_3", 
            SpellDescription = "<b>Chain Lightning lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Hurls a lightning bolt at the enemy that deals <color=\"purple\">LIGHTNING</color> damage and then jumps to additional enemies.\n<color=\"green\">additional jump + 1</color></size>", 
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 3, 10f);} } },
            { "ChainLightning_4", new SpellInfo { SpellName = "ChainLightning_4", 
            SpellDescription = "<b>Chain Lightning lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Hurls a lightning bolt at the enemy that deals <color=\"purple\">LIGHTNING</color> damage and then jumps to additional enemies.\n<color=\"green\">additional jump + 2</color></size>", 
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerChainAttack.Create(pos, GameAssets.i.ChainLightning, PlayerAttacks.TypeSpellElement.Lightning, 5, 5, 10f);} } },

            { "WindBlast_1", new SpellInfo { SpellName = "WindBlast_1", 
            SpellDescription = "<b>Wind Blast lv 1</b>\n\n<size=70%>Fire a projectile at an enemy that deals <color=\"grey\">WIND</color> damage to all enemies in its path.</size>", 
            CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 5, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },
            { "WindBlast_2", new SpellInfo { SpellName = "WindBlast_2", 
            SpellDescription = "<b>Wind Blast lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"grey\">WIND</color> damage to all enemies in its path.\n<color=\"green\">damage + 2\ncooldown -20%</color></size>", 
            CastTime = 2.5f, TimeUntilCast =2.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 7, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },
            { "WindBlast_3", new SpellInfo { SpellName = "WindBlast_3", 
            SpellDescription = "<b>Wind Blast lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"grey\">WIND</color> damage to all enemies in its path.\n<color=\"green\">cooldown -25%</color></size>", 
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 7, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },
            { "WindBlast_4", new SpellInfo { SpellName = "WindBlast_4", 
            SpellDescription = "<b>Wind Blast lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"grey\">WIND</color> damage to all enemies in its path.\n<color=\"green\">damage + 3\ncooldown -50%</color></size>", 
            CastTime = 1f, TimeUntilCast = 1f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.WindBlast, 10, PlayerAttacks.TypeSpellElement.Wind, 7f, 5f);} } },

            { "Tornado_1", new SpellInfo { SpellName = "Tornado_1", 
            SpellDescription = "<b>Tornado lv 1</b>\n\n<size=70%>Cast a tornado at a random position that deals <color=\"grey\">WIND</color> damage to all enemies inside.</size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 3, PlayerAttacks.TypeSpellElement.Wind, 3f, 3f);} } },
            { "Tornado_2", new SpellInfo { SpellName = "Tornado_2", 
            SpellDescription = "<b>Tornado lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Cast a tornado at a random position that deals <color=\"grey\">WIND</color> damage to all enemies inside.\n<color=\"green\">damage + 2\nduration + 1s</color></size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 5, PlayerAttacks.TypeSpellElement.Wind, 4f, 3f);} } },
            { "Tornado_3", new SpellInfo { SpellName = "Tornado_3", 
            SpellDescription = "<b>Tornado lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Cast a tornado at a random position that deals <color=\"grey\">WIND</color> damage to all enemies inside.\n<color=\"green\">duration + 2s</color></size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 5, PlayerAttacks.TypeSpellElement.Wind, 6f, 3f);} } },
            { "Tornado_4", new SpellInfo { SpellName = "Tornado_4", 
            SpellDescription = "<b>Tornado lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Cast a tornado at a random position that deals <color=\"grey\">WIND</color> damage to all enemies inside.\n<color=\"green\">damage + 5\nduration + 4s</color></size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.Tornado, 10, PlayerAttacks.TypeSpellElement.Wind, 10f, 3f);} } },

            { "FrostNova_1", new SpellInfo { SpellName = "FrostNova_1", 
            SpellDescription = "<b>Frost Nova lv 1</b>\n\n<size=70%>Fire a projectile at an enemy that explodes on inpact and deals <color=#1F91A9>FROST</color> damage to all enemies.</size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 2, PlayerAttacks.TypeSpellElement.Frost);} } },
            { "FrostNova_2", new SpellInfo { SpellName = "FrostNova_2", 
            SpellDescription = "<b>Frost Nova lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Fire a projectile at an enemy that explodes on inpact and deals <color=#1F91A9>FROST</color> damage to all enemies.\n<color=\"green\">damage + 3\ncooldown -20%</color></size>", 
            CastTime = 4f, TimeUntilCast = 4f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 5, PlayerAttacks.TypeSpellElement.Frost);} } },
            { "FrostNova_3", new SpellInfo { SpellName = "FrostNova_3", 
            SpellDescription = "<b>Frost Nova lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Fire a projectile at an enemy that explodes on inpact and deals <color=#1F91A9>FROST</color> damage to all enemies.\n<color=\"green\">cooldown -25%</color></size>", 
            CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 5, PlayerAttacks.TypeSpellElement.Frost);} } },
            { "FrostNova_4", new SpellInfo { SpellName = "FrostNova_4", 
            SpellDescription = "<b>Frost Nova lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Fire a projectile at an enemy that explodes on inpact and deals <color=#1F91A9>FROST</color> damage to all enemies.\n<color=\"green\">damage + 5\ncooldown -33%</color></size>", 
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerExplosionAttack.Create(pos, GameAssets.i.FrostNova, PlayerAttacks.TypeSpellElement.Frost, 5f, GameAssets.i.FrostNovaExplosion, 10, PlayerAttacks.TypeSpellElement.Frost);} } },

            { "LightningBolt_1", new SpellInfo { SpellName = "LightningBolt_1", 
            SpellDescription = "<b>Lightning Bolt lv 1</b>\n\n<size=70%>Fire a projectile at an enemy that deals <color=\"purple\">LIGHTNING</color> damage to all enemies in its path.</size>",
            CastTime = 4f, TimeUntilCast = 4f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 10, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },
            { "LightningBolt_2", new SpellInfo { SpellName = "LightningBolt_2", 
            SpellDescription = "<b>Lightning Bolt lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"purple\">LIGHTNING</color> damage to all enemies in its path.\n<color=\"green\">cooldown -25%</color></size>",
            CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 10, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },
            { "LightningBolt_3", new SpellInfo { SpellName = "LightningBolt_3", 
            SpellDescription = "<b>Lightning Bolt lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"purple\">LIGHTNING</color> damage to all enemies in its path.\n<color=\"green\">cooldown -33%</color></size>",
            CastTime = 2f, TimeUntilCast = 2f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 10, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },
            { "LightningBolt_4", new SpellInfo { SpellName = "LightningBolt_4", 
            SpellDescription = "<b>Lightning Bolt lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"purple\">LIGHTNING</color> damage to all enemies in its path.\n<color=\"green\">damage + 5\ncooldown -50%</color></size>",
            CastTime = 1f, TimeUntilCast = 1f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.LightningBolt, 15, PlayerAttacks.TypeSpellElement.Lightning, 7f, 5f);} } },

            { "PyroBlast_1", new SpellInfo { SpellName = "PyroBlast_1", 
            SpellDescription = "<b>Pyro Blast lv 1</b>\n\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage to all enemies in its path.</size>",
            CastTime = 4f, TimeUntilCast = 4f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 10, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },
            { "PyroBlast_2", new SpellInfo { SpellName = "PyroBlast_2", 
            SpellDescription = "<b>Pyro Blast lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage to all enemies in its path.\n<color=\"green\">damage + 2\ncooldown -15%</color></size>",
            CastTime = 3.5f, TimeUntilCast = 3.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 12, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },
            { "PyroBlast_3", new SpellInfo { SpellName = "PyroBlast_3", 
            SpellDescription = "<b>Pyro Blast lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage to all enemies in its path.\n<color=\"green\">damage + 3\ncooldown -15%</color></size>",
            CastTime = 3f, TimeUntilCast = 3f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 15, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },
            { "PyroBlast_4", new SpellInfo { SpellName = "PyroBlast_4", 
            SpellDescription = "<b>Pyro Blast lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Fire a projectile at an enemy that deals <color=\"red\">FIRE</color> damage to all enemies in its path.\n<color=\"green\">cooldown -50%</color></size>",
            CastTime = 1.5f, TimeUntilCast = 1.5f, 
            SpawnSpell = (Vector3 pos) => { PlayerWaveAttack.Create(pos, GameAssets.i.PyroBlast, 15, PlayerAttacks.TypeSpellElement.Fire, 7f, 5f);} } },

            { "FrostRing_1", new SpellInfo { SpellName = "FrostRing_1", 
            SpellDescription = "<b>Frost Ring lv 1</b>\n\n<size=70%>Cast a frost ring at a random position that deals <color=#1F91A9>FROST</color> damage to all enemies inside.</size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 5, PlayerAttacks.TypeSpellElement.Frost, 3f, 3f);} } },
            { "FrostRing_2", new SpellInfo { SpellName = "FrostRing_2", 
            SpellDescription = "<b>Frost Ring lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Cast a frost ring at a random position that deals <color=#1F91A9>FROST</color> damage to all enemies inside.\n<color=\"green\">damage + 1\nduration + 1s</color></size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 6, PlayerAttacks.TypeSpellElement.Frost, 4f, 3f);} } },
            { "FrostRing_3", new SpellInfo { SpellName = "FrostRing_3", 
            SpellDescription = "<b>Frost Ring lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Cast a frost ring at a random position that deals <color=#1F91A9>FROST</color> damage to all enemies inside.\n<color=\"green\">damage + 2\nduration + 1s</color></size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 8, PlayerAttacks.TypeSpellElement.Frost, 5f, 3f);} } },
            { "FrostRing_4", new SpellInfo { SpellName = "FrostRing_4", 
            SpellDescription = "<b>Frost Ring lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Cast a frost ring at a random position that deals <color=#1F91A9>FROST</color> damage to all enemies inside.\n<color=\"green\">damage + 2\nduration + 5s</color></size>", 
            CastTime = 5f, TimeUntilCast = 5f, 
            SpawnSpell = (Vector3 pos) => { PlayerStaticPointAttack.Create(pos, GameAssets.i.FrostRing, 10, PlayerAttacks.TypeSpellElement.Frost, 10f, 3f);} } },

            { "FrostOrb_1", new SpellInfo { SpellName = "FrostOrb_1", 
            SpellDescription = "<b>Frost Orb lv 1</b>\n\n<size=70%>Cast a orb that rotates around you and deals <color=#1F91A9>FROST</color> damage to enemies.</size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 5, PlayerAttacks.TypeSpellElement.Frost, 2f, 2f);} } },
            { "FrostOrb_2", new SpellInfo { SpellName = "FrostOrb_2", 
            SpellDescription = "<b>Frost Orb lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Cast a orb that rotates around you and deals <color=#1F91A9>FROST</color> damage to enemies.\n<color=\"green\">summon additional orb</color></size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 5, PlayerAttacks.TypeSpellElement.Frost, 2f, 3f);} } },
            { "FrostOrb_3", new SpellInfo { SpellName = "FrostOrb_3", 
            SpellDescription = "<b>Frost Orb lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Cast a orb that rotates around you and deals <color=#1F91A9>FROST</color> damage to enemies.\n<color=\"green\">summon additional orb</color></size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 5, PlayerAttacks.TypeSpellElement.Frost, 2f, 4f);} } },
            { "FrostOrb_4", new SpellInfo { SpellName = "FrostOrb_4", 
            SpellDescription = "<b>Frost Orb lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Cast a orb that rotates around you and deals <color=#1F91A9>FROST</color> damage to enemies.\n<color=\"green\">summon additional orb</color></size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.FrostOrb, 10, PlayerAttacks.TypeSpellElement.Frost, 2f, 5f);} } },

            { "LightningOrb_1", new SpellInfo { SpellName = "LightningOrb_1", 
            SpellDescription = "<b>Lightning Orb lv 1</b>\n\n<size=70%>Cast a orb that rotates around you and deals <color=\"purple\">LIGHTNING</color> damage to enemies.</size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 7, PlayerAttacks.TypeSpellElement.Lightning, 2f, 2f);} } },
            { "LightningOrb_2", new SpellInfo { SpellName = "LightningOrb_2", 
            SpellDescription = "<b>Lightning Orb lv 1 -> <color=\"green\">lv 2</color></b>\n<size=70%>Cast a orb that rotates around you and deals <color=\"purple\">LIGHTNING</color> damage to enemies.\n<color=\"green\">summon additional orb</color></size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 7, PlayerAttacks.TypeSpellElement.Lightning, 2f, 3f);} } },
            { "LightningOrb_3", new SpellInfo { SpellName = "LightningOrb_3", 
            SpellDescription = "<b>Lightning Orb lv 2 -> <color=\"green\">lv 3</color></b>\n<size=70%>Cast a orb that rotates around you and deals <color=\"purple\">LIGHTNING</color> damage to enemies.\n<color=\"green\">summon additional orb</color></size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f,
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 7, PlayerAttacks.TypeSpellElement.Lightning, 2f, 4f);} } },
            { "LightningOrb_4", new SpellInfo { SpellName = "LightningOrb_4", 
            SpellDescription = "<b>Lightning Orb lv 3 -> <color=\"green\">lv 4</color></b>\n<size=70%>Cast a orb that rotates around you and deals <color=\"purple\">LIGHTNING</color> damage to enemies.\n<color=\"green\">summon additional orb</color></size>", 
            CastTime = float.PositiveInfinity, TimeUntilCast = 0f, 
            SpawnSpell = (Vector3 pos) => { PlayerRotationAttack.Create(pos, GameAssets.i.LightningOrb, 12, PlayerAttacks.TypeSpellElement.Lightning, 2f, 5f);} } },
 

        };
        return spells;
    }


    public static List<string> GetDefaultSpells(){
        List<string> defaultSpells = new List<string> {"FireBall_1", "FrostBall_1", "ChainLightning_1", "WindBlast_1", "Tornado_1", "FrostNova_1", "LightningBolt_1", 
        "PyroBlast_1", "FrostRing_1", "FrostOrb_1", "LightningOrb_1"};
        return defaultSpells;
    }



    public static SpellInfo GetSpellInfo(string key){
        return GetDictionary()[key];
    }
}
