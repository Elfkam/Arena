using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LevelUpMenu : MonoBehaviour
{
    public void SelectSpellStartMenu(){
        List<string> spells = SpellsData.GetDefaultSpells();
        List<string> spellsToButtons = new List<string>();
        List<int> indexes = GetRandomNumber(0, spells.Count, 3);
        // Get 3 random spells
        for (int i = 0; i < indexes.Count; i++)
        {
            spellsToButtons.Add(spells[indexes[i]]);
        }
        SetButtons(spellsToButtons);
    }
    public void LevelUpSetup(){
        List<string> spells = GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().GetAvailableSpells();
        List<string> spellsToButtons = new List<string>();

        GameObject.Find("GameHandler/UI/LevelUpMenu/Header/Description").GetComponent<TextMeshProUGUI>().SetText("Level Up!");
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
            if(btn.gameObject.name == "Icon"){
                string spell = spellsToButtons[i];
                string nameOfSpell = spell.Substring(0,  spell.Length - 2);
                char rankOfSpell = spell[spell.Length - 1];

                //set frame
                btn.transform.parent.GetComponent<Outline>().effectColor = GetFrameColor(Int32.Parse(rankOfSpell.ToString()));

                // set img
                btn.sprite = Resources.Load<Sprite>("Icons/" + nameOfSpell);

                // set text
                GameObject text = btn.transform.parent.gameObject.transform.GetChild(1).gameObject;
                string textS = SpellsData.GetDictionary()[spellsToButtons[i]].SpellDescription;
                text.GetComponent<TextMeshProUGUI>().SetText(textS);
                i++;                
            }
        }
        GameObject.Find("GameHandler/UI/LevelUpMenu").SetActive(true);
    }

    public void ChooseSpell()
    {
        string spellName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Spells>().LearnNewSpell(spellName);
        GameObject.Find("GameHandler/UI/LevelUpMenu").SetActive(false);
        GameObject.Find("GameHandler/UI/Floating Joystick").SetActive(true);
        GameObject.Find("GameHandler/UI/Health Bar").SetActive(true);
        GameObject.Find("GameHandler/UI/PauseButton").SetActive(true);
        Time.timeScale = 1;
        GameObject.Find("GameHandler/UI/LevelUpMenu/Row4/Button/Description").GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void Reroll()
    {
        FindAnyObjectByType<AudioManager>().Play("BtnClick");
        LevelUpSetup();
        GameObject.Find("GameHandler/UI/LevelUpMenu/Row4/Button/Description").GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 60f/255f);
    }

    private Color GetFrameColor(int level){
        switch (level)
        {
            case(4):
                return new Color(1f, 0f, 165f/255f);
            case(3):
            case(2):
                return new Color(0f, 15f/255f, 1f);
            default:
                return new Color(1f, 1f, 1f);
        }
    }
}
