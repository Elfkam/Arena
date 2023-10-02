using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowXP : MonoBehaviour
{
    public Slider slider;

    public void SetMaxXP(int xp){
        slider.maxValue = xp;
        slider.value = 0;
    }

    public void SetXP(int xp){
        slider.value = xp;
    }
}
