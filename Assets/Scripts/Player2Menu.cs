using UnityEngine;

public class Player2Menu : MonoBehaviour
{
    public GameObject character2;
    private SpriteRenderer player2SpriteRenderer;
    private SpriteRenderer character2SpriteRenderer;

    private void Start()
    {
        player2SpriteRenderer = GetComponent<SpriteRenderer>();
        character2SpriteRenderer = character2.GetComponent<SpriteRenderer>();
        player2SpriteRenderer.sprite = character2SpriteRenderer.sprite;
    }

    private void Update()
    {
        if (character2SpriteRenderer.sprite != player2SpriteRenderer.sprite)
        {
            player2SpriteRenderer.sprite = character2SpriteRenderer.sprite;
        }
    }
}
