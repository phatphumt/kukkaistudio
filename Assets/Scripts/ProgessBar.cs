using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgessBar : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] TMP_Text hptext;

    public void UpdateHPBar(float newHP)
    {
        hptext.text = $"{(int)newHP}/100";
        bar.fillAmount = newHP / 100;
    }
}
