using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class briefClass : MonoBehaviour
{
    public UnityEvent kliktOpbrief;
    public UnityEvent plaatstEmoji;
    public EmojiVastlegger EMVLRef;
    public GameObject emojiGeplaatsdPrefab;

    private void Start()
    {
        EMVLRef = FindObjectOfType<EmojiVastlegger>();
    }

    private void OnMouseDown()
    {
        Debug.Log("klikt op brief");
        kliktOpbrief.Invoke();
        if (EMVLRef.emojiGeselecteerd)
        {
            plaatstEmoji.Invoke();
        }
    }

    public void plaatsEmojiOpMij()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        GameObject prefab =  Instantiate(emojiGeplaatsdPrefab, pos, Quaternion.identity);
        prefab.GetComponent<SpriteRenderer>().sprite = EMVLRef.geselecteerdeEmojiSprite;
        prefab.transform.SetParent(transform);
    }
}
