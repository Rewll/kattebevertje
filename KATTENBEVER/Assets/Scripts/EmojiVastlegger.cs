using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EmojiVastlegger : MonoBehaviour
{
    [Header("Camera dingen")]
    [SerializeField] Camera cam1;
    public string emojiBestandNaam;
    [Space]
    [Header("Emoji Plekken Dingen")]
    public List<EmojiClass> emojis = new List<EmojiClass>();
    int plekNummer;
    public SpriteRenderer sprit;

    private void Start()
    {
        //sprit.sprite = Resources.Load<Sprite>("Emojis/Emoji4");
    }

    public void legEmojiVast()
    {
        if (plekjeVrijCheck())
        {
            StartCoroutine(CoroutineScreenshot());
        }
        else if (!plekjeVrijCheck())
        {
            Debug.Log("Eerst eentje verwijderen!!");
        }
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

    void plaatsEmojiOpPlek(int plek)
    {
        EmojiClass emojiClasRefje = emojis[plek];
        emojiClasRefje.gevuld = true;
        emojiClasRefje.emojiSprite = Resources.Load<Sprite>("Emojis/Emoji" + plekNummer);
        emojiClasRefje.spritePlek.GetComponent<SpriteRenderer>().sprite = emojiClasRefje.emojiSprite; 
    }

    void fotografeerEmoji(Camera cam)
    {
        int width = 600;
        int height = 600;
        RenderTexture screenTexture = new RenderTexture(width, height, 16);
        cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        cam.Render();
        Texture2D renderedTexture = new Texture2D(width, height);
        renderedTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        RenderTexture.active = null;


        byte[] byteArray = renderedTexture.EncodeToPNG();

        if (plekjeVrijCheck())
        {
            System.IO.File.WriteAllBytes(Application.dataPath + ("/Resources/Emojis/" + emojiBestandNaam + plekNummer + ".png"), byteArray);
            plaatsEmojiOpPlek(plekNummer);
        }
        else if(!plekjeVrijCheck())
        {
            Debug.Log("Eerst eentje verwijderen!!");
        }
    }
    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;
        Texture2D screenshotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, width, height);
        screenshotTexture.ReadPixels(rect, 0, 0);
        screenshotTexture.Apply();

        byte[] byteArray = screenshotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + ("/Resources/Emojis/Emoji" + plekNummer + ".png"), byteArray);
        plaatsEmojiOpPlek(plekNummer);
    }

}