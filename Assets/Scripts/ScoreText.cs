using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text mText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateText(int amount)
    {
        mText.text = amount.ToString();
    }
}
