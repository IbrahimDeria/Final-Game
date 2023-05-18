using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject settingsPopUp;
    public GameObject backButton;

    private Color originalColor;
    private Color highlightColor;

    void Start()
    {
        originalColor = spriteRenderer.color;
        highlightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);

        settingsPopUp.SetActive(false);
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
        settingsPopUp.SetActive(true);
    }
}
