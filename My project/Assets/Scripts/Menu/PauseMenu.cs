using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public void GiveUp()
    {
        FindAnyObjectByType<AudioManager>().Play("BtnClick");
        int bonusCoins = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetCoins();
        GameData.SetCoins(GameData.GetCoins() + bonusCoins);
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(true);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void PauseMenuButton(){
        FindAnyObjectByType<AudioManager>().Play("BtnClick");
        SetButtons(GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().GetLearnedSpells());
        gameObject.SetActive(true);
        SetUpHeader();
        PauseGame();
    }

    private void SetButtons(List<string> spellsToButtons){
        GameObject gm = GameObject.Find("GameHandler/UI/PauseMenu/PlayerInfo/LearnedSpells");
        int i = 0;

        foreach (var spell in spellsToButtons)
        {
            string nameOfSpell = spell.Substring(0,  spell.Length - 2);
            if(gm.transform.GetChild(i) != null) {
                gm.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + nameOfSpell);
                gm.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
                // set rank
                gm.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Lv " + spell[spell.Length - 1]);
            }
            i++;
        }
    }

    private void SetUpHeader(){
        GameObject gm = GameObject.Find("GameHandler/UI/PauseMenu/Header/Description");
        switch(GameData.GetCurrDiffLevel()){
            case 1 :
                gm.GetComponent<TextMeshProUGUI>().text = "PAUSED\n\n<color=\"green\">- EASY -";
                return;
            case 2 :
                gm.GetComponent<TextMeshProUGUI>().text = "PAUSED\n\n<color=\"orange\">- MEDIUM -";
                return;
            case 3 :
                gm.GetComponent<TextMeshProUGUI>().text = "PAUSED\n\n<color=\"red\">- HARD -";
                return;
            case 4 :
                gm.GetComponent<TextMeshProUGUI>().text = "PAUSED\n\n<color=\"purple\">- IMPOSSIBLE -";
                return;
            default :
                return;
        } 
    }

    public void PauseGame(){
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        Time.timeScale = 0; //pause game
    }

    public void ResumeGame(){
        FindAnyObjectByType<AudioManager>().Play("BtnClick");
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(true);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1; //pause game
    }
}
