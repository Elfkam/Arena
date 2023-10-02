using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private GameObject HeaderDesc;
    public void SetActiveEndMenu(bool playerWon){
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
        HeaderDesc.GetComponent<TextMeshProUGUI>().text = playerWon ? "<color=yellow>YOU WIN!" : "<color=red>YOU DIED";
        foreach (var outline in gameObject.transform.GetComponentsInChildren<Outline>())
        {
            outline.effectColor = playerWon ? new Color(255, 241f/255f, 0) : new Color(255, 0, 0);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<DamageDone>().AddRows();
        gameObject.SetActive(true);
        Time.timeScale = 0;      
    }
    public void MainMenu()
    {
        FindAnyObjectByType<AudioManager>().Play("BtnClick");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
