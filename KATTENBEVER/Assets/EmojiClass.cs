using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class EmojiClass : MonoBehaviour
{
    public bool gevuld;
    public Sprite emojiSprite;
    //public GameObject spritePlek;
    [Space]
    public GameObject selecteerKnop;

    private void Update()
    {
        if (gevuld)
        {
            selecteerKnop.SetActive(true);
        }
        else if (!gevuld)
        {
            selecteerKnop.SetActive(false);
        }
    }
}