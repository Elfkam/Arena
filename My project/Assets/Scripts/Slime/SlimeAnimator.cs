using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private Slime slime;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update(){
        animator.SetBool(IS_WALKING, slime.IsWalking());
    }
}
