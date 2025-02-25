using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LabelPress : Interactable
{
    public Button button;
    public Sprite[] shapes;
    public int counter = 0;
    void Start()
    {
        button = GetComponent<Button>();
        button.GetComponent<Image>().sprite = shapes[counter];
    }

    // Update is called once per frame
    public override void OnClick()
    {
        button.GetComponent<Image>().sprite = shapes[(counter+1)%6];
    }
}
