using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private GameObject HeaderDesc;
    public void SetActiveEndMenu(bool playerWon){
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
        HeaderDesc.GetComponent<TextMeshProUGUI>().text = playerWon ? "<color=yellow>YOU WIN!" : "<color=red>GAME OVER";
        GameObject.FindGameObjectWithTag("Player").GetComponent<DamageDone>().AddRows();
        gameObject.SetActive(true);
        Time.timeScale = 0;      
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
