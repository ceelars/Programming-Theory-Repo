using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColor : MonoBehaviour
{
    [SerializeField]
    private string orbColorString;
    [SerializeField]
    private float alphaFloat;

    private void Start()
    {
        FindColor();
        SetOpacity(alphaFloat);
    }
    private void FindColor()
    {
        Color orbColor = DataManager.GetColor(orbColorString);

        if (gameObject.GetComponent<Image>() != null)
        {
            gameObject.GetComponent<Image>().color = orbColor / 255;
        }
    }

    private void SetOpacity(float alpha)
    {
        float orbAlpha = gameObject.GetComponent<Image>().color.a;
        orbAlpha = alpha / 255;
    }
}
