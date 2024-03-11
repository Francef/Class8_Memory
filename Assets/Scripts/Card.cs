using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] GameObject cardBack;
    [SerializeField] SpriteRenderer spriteRenderer;
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }

    public void setFaceVisible(bool visible)
    {
        cardBack.SetActive(!visible);
    }
    private void OnMouseDown()
    {
        setFaceVisible(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
