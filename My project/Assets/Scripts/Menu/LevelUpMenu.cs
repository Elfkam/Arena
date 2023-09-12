using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LevelUpMenu : MonoBehaviour
{
    public void SelectSpellStartMenu(){
        List<string> spellsToButtons = new List<string>
        {
            "FireBall_1",
            "FrostBall_1",
            "ChainLightning_1"
        };
        SetButtons(spellsToButtons);
    }
    public void LevelUpSetup(){
        List<string> spells = GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().GetAvailableSpells();
        List<string> spellsToButtons = new List<string>();


        List<int> indexes = GetRandomNumber(0, spells.Count, 3);
        // Get 3 random spells
        for (int i = 0; i < indexes.Count; i++)
        {
            spellsToButtons.Add(spells[indexes[i]]);
        }
        SetButtons(spellsToButtons);
    }

    public List<int> GetRandomNumber(int from,int to,int numberOfElement)
    {
        HashSet<int> numbers = new HashSet<int>();
        while (numbers.Count < numberOfElement)
        {
            numbers.Add(UnityEngine.Random.Range(from, to));
        }
        return numbers.ToList();
    }

    private void SetButtons(List<string> spellsToButtons){
        Image [] buttons = GetComponentsInChildren<Image>();
        int i = 0;
        foreach (Image btn in buttons)
        {
            if(btn.gameObject.name == "Button"){
                string spell = spellsToButtons[i];
                string nameOfSpell = spell.Substring(0,  spell.Length - 2);
                char rankOfSpell = spell[spell.Length - 1];

                // set img
                btn.sprite = Resources.Load<Sprite>("Icons/" + nameOfSpell);

                // set text
                GameObject text = btn.transform.parent.gameObject.transform.GetChild(1).gameObject;
                text.GetComponent<TextMeshProUGUI>().SetText(nameOfSpell + " lv-" + rankOfSpell);
                i++;                
            }
        }
        GameObject.Find("GameHandler/UI/LevelUpMenu").SetActive(true);
    }

    public void ChooseSpell()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().LearnNewSpell(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name);
        GameObject.Find("GameHandler/UI/LevelUpMenu").SetActive(false);
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(true);
        Time.timeScale = 1;
    }
}
