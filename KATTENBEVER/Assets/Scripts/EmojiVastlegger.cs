using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EmojiVastlegger : MonoBehaviour
{
    [Header("Camera dingen")]
    [SerializeField] Camera cam1;
    [Space]
    [Header("Emoji Plekken Dingen")]
    public List<EmojiClass> emojis = new List<EmojiClass>();
    int plekNummer = 0;
    public SpriteRenderer fotoOpnameArea;

    private void Start()
    {
        //sprit.sprite = Resources.Load<Sprite>("gezichten/Emoji4"); //resources.loadtest
    }

    public void legEmojiVast()
    {
        if (plekjeVrijCheck())
        {
            StartCoroutine(CoroutineScreenshot());
        }
        else
        {
            Debug.Log("Verwijder eerst eentje!!");
        }
        
    }

    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();
        int width = 800;
        int height = 800;
        Texture2D screenShotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, width, height);
        screenShotTexture.ReadPixels(rect, 0, 0); //print rectangle on the texture, 0, 0 post on the texture
        screenShotTexture.Apply();

        byte[] byteArray = screenShotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes("Assets/Resources/Gezichten/Emoji" + plekNummer + ".png", byteArray);
        Sprite tempSprite = Sprite.Create(screenShotTexture, rect, new Vector2(0.5f, 0.5f));
        plaatsEmojiOpPlek(plekNummer, tempSprite);
    }

    bool plekjeVrijCheck()
    {
        foreach (EmojiClass emojiPlek in emojis)
        {
            if (emojiPlek.gevuld)
            {
                continue;
            }
            else if (!emojiPlek.gevuld)
            {
                plekNummer = emojis.IndexOf(emojiPlek);
                return true;
            }       
        }        
        return false;
    }

    void plaatsEmojiOpPlek(int plek, Sprite sprite)
    {
        EmojiClass emojiClasRefje = emojis[plek];
        emojiClasRefje.gevuld = true;
        emojiClasRefje.emojiSprite = sprite;
        emojiClasRefje.spritePlek.GetComponent<SpriteRenderer>().sprite = emojiClasRefje.emojiSprite; 
    }
}