using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Button muteBtn;

    private void Start(){
        if(AudioListener.volume == 0){
            muteBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Buttons/" + "SoundOn");
        }else{            
            muteBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Buttons/" + "SoundOff");
        }
    }

    public void ToggleMuteAllSound()
    {
        if(AudioListener.volume == 0){
            // unMute
            AudioListener.volume = 1;
            muteBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Buttons/" + "SoundOff");

        }else{
            //Mute
            AudioListener.volume = 0;
            muteBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Buttons/" + "SoundOn");
        }
    }
}
