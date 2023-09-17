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

    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCriticalHit, PlayerAttacks.TypeSpellElement typeSpellElement){
        Transform damagePopupTransform = Instantiate(GameAssets.i.DamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit, typeSpellElement);
        return damagePopup;
    }

    public void Setup(int damageAmount, bool isCriticalHit, PlayerAttacks.TypeSpellElement typeSpellElement){
        textMesh.SetText(damageAmount.ToString());
        textMesh.color = GetColor(typeSpellElement);
        timeUntilDisappearStart = 1f;
    }

    private Color GetColor(PlayerAttacks.TypeSpellElement typeSpellElement){
        if(PlayerAttacks.TypeSpellElement.Fire == typeSpellElement) return Color.yellow;
        if(PlayerAttacks.TypeSpellElement.Frost == typeSpellElement) return Color.cyan;
        if(PlayerAttacks.TypeSpellElement.Lightning == typeSpellElement) return Color.magenta;
        if(PlayerAttacks.TypeSpellElement.Wind == typeSpellElement) return Color.white;
        return Color.red;
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
