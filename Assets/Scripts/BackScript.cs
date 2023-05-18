using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color highlightColor;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = spriteRenderer.color;
        highlightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        spriteRenderer.color = highlightColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }

    void OnDisable()
    {
        spriteRenderer.color = originalColor;
    }
    
    void OnMouseDown()
    {
        GameObject settingsPopUp = transform.parent.gameObject;
        settingsPopUp.SetActive(false);
    }

}
