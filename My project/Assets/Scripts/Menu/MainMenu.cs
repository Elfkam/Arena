using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject DifficultyMenu;
    public void SelectDiff()
    {
        gameObject.SetActive(false);
        DifficultyMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
