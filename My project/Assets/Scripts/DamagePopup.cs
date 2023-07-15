using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{  
    private TextMeshPro textMesh;
    private float timeUntilDisappearStart;
    private Color textColor;
    private void Awake() {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    private void Update(){
        Disappear();
    }

    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCriticalHit){
        Transform damagePopupTransform = Instantiate(GameAssets.i.DamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit);
        return damagePopup;
    }

    public void Setup(int damageAmount, bool isCriticalHit){
        textMesh.SetText(damageAmount.ToString());
        if(isCriticalHit){
            textMesh.fontSize = 10;
            textColor = Color.yellow;
        }else{
            textMesh.fontSize = 8;
            textColor = Color.red;
        }
        textMesh.color = textColor;
        timeUntilDisappearStart = 1f;
    }

    private void Disappear(){
        float moveYSpeed = 0.5f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        timeUntilDisappearStart -= Time.deltaTime;
        if(timeUntilDisappearStart < 0){
            float disappearSpeed = 0.5f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0){
                Destroy(gameObject);
            }
        }
    }
}
