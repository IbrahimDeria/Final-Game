using UnityEngine;

public class Player1Menu : MonoBehaviour
{
    public GameObject character1;
    private SpriteRenderer player1SpriteRenderer;
    private SpriteRenderer character1SpriteRenderer;

    private void Start()
    {
        player1SpriteRenderer = GetComponent<SpriteRenderer>();
        character1SpriteRenderer = character1.GetComponent<SpriteRenderer>();
        player1SpriteRenderer.sprite = character1SpriteRenderer.sprite;
    }

    private void Update()
    {
        if (character1SpriteRenderer.sprite != player1SpriteRenderer.sprite)
        {
            player1SpriteRenderer.sprite = character1SpriteRenderer.sprite;
        }
    }
}
