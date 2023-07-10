using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private Enemy enemy;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update(){
        animator.SetBool(IS_WALKING, enemy.IsWalking());
    }
}
