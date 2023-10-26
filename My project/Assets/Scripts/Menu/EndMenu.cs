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
        Time.timeScale = 0;    
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(false);
        int bonusCoins = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetCoins();
        SetUpHeader(playerWon, bonusCoins);
        foreach (var outline in gameObject.transform.GetComponentsInChildren<Outline>())
        {
            outline.effectColor = playerWon ? new Color(255, 241f/255f, 0) : new Color(255, 0, 0);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<DamageDone>().AddRows();
        GameData.SetCoins(GameData.GetCoins() + bonusCoins);
        if(playerWon) {
            if(GameData.GetCurrDiffLevel() >= GameData.GetMaxDiffLevel()){
                GameData.SetMaxDiffLevel(GameData.GetMaxDiffLevel() + 1);
            }            
        }
        gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<DamageDone>().GetTable().transform.parent.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1); // works only if gameObject is active
    }
    public void MainMenu()
    {
        FindAnyObjectByType<AudioManager>().Play("BtnClick");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    private void SetUpHeader(bool playerWon, int bonusCoins){
        switch(GameData.GetCurrDiffLevel()){
            case 1 :
                HeaderDesc.GetComponent<TextMeshProUGUI>().text = (playerWon ? "<color=yellow>YOU WIN!" : "<color=red>YOU DIED") + "\n\n<color=\"green\">- EASY -\n\n<color=yellow>+ "+bonusCoins+" COINS";
                return;
            case 2 :
                HeaderDesc.GetComponent<TextMeshProUGUI>().text = (playerWon ? "<color=yellow>YOU WIN!" : "<color=red>YOU DIED") + "\n\n<color=\"orange\">- MEDIUM -\n\n<color=yellow>+ "+bonusCoins+" COINS";
                return;
            case 3 :
                 HeaderDesc.GetComponent<TextMeshProUGUI>().text = (playerWon ? "<color=yellow>YOU WIN!" : "<color=red>YOU DIED")+ "\n\n<color=\"red\">- HARD -\n\n<color=yellow>+ "+bonusCoins+" COINS";
                return;
            case 4 :
                 HeaderDesc.GetComponent<TextMeshProUGUI>().text = (playerWon ? "<color=yellow>YOU WIN!" : "<color=red>YOU DIED")+ "\n\n<color=\"purple\">- IMPOSSIBLE -\n\n<color=yellow>+ "+bonusCoins+" COINS";
                return;
            default :
                return;
        } 
    }
}
