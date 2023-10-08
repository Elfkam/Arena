using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void SetActiveReviveMenu(){
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
        Time.timeScale = 0;    
        gameObject.SetActive(true);
    }

    public void DisableReviveMenu(){
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(true);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(true);
        Time.timeScale = 1;    
        gameObject.SetActive(false);
    }
}
