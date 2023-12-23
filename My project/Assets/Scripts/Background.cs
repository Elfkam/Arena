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
        spriteRenderer.color = SetBackgroundBasedOnLevel();

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
    private Color SetBackgroundBasedOnLevel()
    {
        switch(GameData.GetCurrDiffLevel()){
            case 1: return new Color(185f/255f, 201f/255f, 241f/255f);
            case 2: return new Color(152f/255f, 150f/255f, 232f/255f);
            case 3: return new Color(250f/255f, 197f/255f, 152f/255f);
            case 4: return new Color(255f/255f, 224f/255f, 129f/255f);
            default: return new Color(185f/255f, 201f/255f, 241f/255f);
        }
    }
}
