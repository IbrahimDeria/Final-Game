using UnityEngine;

public class SpriteChanger1 : MonoBehaviour
{
    public Sprite[] characterSprites; // Array of different character sprites corresponding to each color

    private SpriteRenderer spriteRenderer; // Reference to the character's SpriteRenderer component

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeCharacterSprite(int colorIndex)
    {
        if (colorIndex >= 0 && colorIndex < characterSprites.Length)
        {
            spriteRenderer.sprite = characterSprites[colorIndex];
        }
    }
}
