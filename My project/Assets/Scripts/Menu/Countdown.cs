using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private EndMenu endMenu;
    private float timeLeft;
    private bool isEndMenuActive;
    private void Start()
    {
        timeLeft = 300; 
        isEndMenuActive = false;
    }

    private void Update()
    {
        if(!isEndMenuActive){
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0){
                endMenu.SetActiveEndMenu(true);
                isEndMenuActive = true;
            }
            UpdateText();
        }
    }

    private void UpdateText(){
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.RoundToInt(timeLeft % 60f);

        //string formatedSeconds = seconds.ToString();

        if (seconds == 60){
            seconds = 0;
            minutes += 1;
        }
        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
