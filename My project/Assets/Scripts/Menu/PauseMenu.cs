using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public void GiveUp()
    {
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(true);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void PauseMenuButton(){
        SetButtons(GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().GetLearnedSpells());
        gameObject.SetActive(true);
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

    public void PauseGame(){
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(false);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(false);
        Time.timeScale = 0; //pause game
    }

    public void ResumeGame(){
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(true);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1; //pause game
    }
}
