using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i {
        get {
            if(_i == null)  _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public Transform DamagePopup;
    public GameObject UndeadSkeleton;
    public GameObject UndeadGhost;
    public GameObject UndeadZombie;
    public GameObject UndeadVampire;
    public GameObject UndeadBlackKnight;
    public GameObject BasicFireBall;
    public GameObject FireBall;
    public GameObject FireBallExplosion;
    public GameObject BasicFrostBall;
    public GameObject ChainLightning;
    public GameObject WindBlast;
    public GameObject Tornado;
    public GameObject FrostNova;
    public GameObject FrostNovaExplosion;
    public GameObject LightningBolt;
    public GameObject PyroBlast;
    public GameObject FrostRing;
    public GameObject FrostOrb;
    public GameObject LightningOrb;
    public GameObject FireDebuff;
    public GameObject EnemyAttack;
}
