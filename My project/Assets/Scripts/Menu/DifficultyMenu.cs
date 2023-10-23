using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private Button easy;
    [SerializeField] private Button medium;
    [SerializeField] private Button hard;
    [SerializeField] private Button impossible;

    public void SetActive(){
        int diffLevel = GameData.GetMaxDiffLevel();
        switch(diffLevel){
            case 1 :
                // unlock only easy diff
                easy.interactable = true;                
                DisableButton(medium);
                DisableButton(hard);
                DisableButton(impossible);
                break;
            case 2 :
                // unlock easy and medium diff
                easy.interactable = true;
                medium.interactable = true;
                DisableButton(hard);
                DisableButton(impossible);
                break;
            case 3 :
                // unlock easy, medium and hard diff
                easy.interactable = true;                
                medium.interactable = true;
                hard.interactable = true;
                DisableButton(impossible);
                break;
            case 4 :
                // unlock all diff
                easy.interactable = true;
                hard.interactable = true;
                medium.interactable = true;
                impossible.interactable = true;
                break;
            default:
                easy.interactable = true;
                hard.interactable = true;
                medium.interactable = true;
                impossible.interactable = true;
                break;
        }
        gameObject.SetActive(true);
    }

    private void DisableButton(Button btn){
        btn.interactable = false;
        Color newColor = btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
        newColor.a = 125.0f/255f;
        btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = newColor;
        btn.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void PlayGame(int diffLevel)
    {
        GameData.SetCurrDiffLevel(diffLevel);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
