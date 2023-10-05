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

    private void Awake()
    {
        int diffLevel = PlayerPrefs.GetInt("DiffLevel");
        Debug.Log(diffLevel);
        switch(diffLevel){
            case 0 :
                // unlock only easy diff
                easy.interactable = true;                
                DisableButton(medium);
                DisableButton(hard);
                DisableButton(impossible);
                return;
            case 1 :
                // unlock easy and medium diff
                easy.interactable = true;
                medium.interactable = true;
                DisableButton(hard);
                DisableButton(impossible);
                return;
            case 2 :
                // unlock easy, medium and hard diff
                easy.interactable = true;                
                medium.interactable = true;
                hard.interactable = true;
                DisableButton(impossible);
                return;
            case 3 :
                // unlock all diff
                easy.interactable = true;
                hard.interactable = true;
                medium.interactable = true;
                impossible.interactable = true;
                return;
            default:
                easy.interactable = true;                
                DisableButton(medium);
                DisableButton(hard);
                DisableButton(impossible);
                return;
        }
    }

    private void DisableButton(Button btn){
        btn.interactable = false;
        Color newColor = btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
        newColor.a = 125.0f/255f;
        btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = newColor;
    }

    public void PlayGame(int diffLevel)
    {
        GameData.SetDiffLevel(diffLevel);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
