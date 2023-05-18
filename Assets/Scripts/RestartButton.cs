using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Color originalColor;
    private Color highlightColor;

    void Start()
    {
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
    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        CharacterController2D player = FindObjectOfType<CharacterController2D>();
        if (player != null)
        {
            player.ResetLives();
        }
        PauseMenu pauseMenu = GetComponentInParent<PauseMenu>();
        pauseMenu.Resume();
    }

}
