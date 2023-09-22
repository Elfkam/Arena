using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private SpriteRenderer spriteRenderer;
    private float offSet = 7f;

    private void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {   
        if(Math.Abs(Math.Abs(transform.position.x) - Math.Abs(player.transform.position.x))  > spriteRenderer.bounds.size.x / 2 - offSet){
            transform.position = player.transform.position;
        }
        if(Math.Abs(Math.Abs(transform.position.y) - Math.Abs(player.transform.position.y))  > spriteRenderer.bounds.size.y / 2 - offSet){
            transform.position = player.transform.position;
        }
    }
}
