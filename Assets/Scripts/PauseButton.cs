using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private bool isPaused = false;
    private SpriteRenderer spriteRenderer;

    private Color originalColor;
    private Color highlightColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(8.3f, 4.3f, 0f);

        originalColor = spriteRenderer.color;
        highlightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
    }

    void OnMouseEnter()
    {
        spriteRenderer.color = highlightColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }

    void OnMouseDown()
    {
        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu != null)
        {
            pauseMenu.TogglePause();
            isPaused = !isPaused;
        }
    }
}
