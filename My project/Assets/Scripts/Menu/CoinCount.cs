using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "0";
    }

    public void SetCoinText(string value){
        text.text = value;
    }
    
}
