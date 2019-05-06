using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvButtonScript : MonoBehaviour
{
    public Item Item;
    public Button ButtonParent;
    public string Text;

    void Start() { }
    void Update() { }

    public void SetFields(string text, Item item)
    {
        Text = text;
        Item = item;
        ButtonParent.GetComponentInChildren<Text>().text = Text;
    }
}
