using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    private SpriteRenderer[] buttonRenderers;
    private Collider2D resumeCollider;
    public GameObject popUp; // Declare at class level
    private SpriteRenderer popUpRenderer; // Declare at class level

    void Start()
    {
        buttonRenderers = GetComponentsInChildren<SpriteRenderer>();
        SetButtonPositions();

        // Get the collider of the resume button
        resumeCollider = transform.Find("ResumeButton").GetComponent<Collider2D>();

        // Get the SpriteRenderer of the popUp GameObject
        if (popUp != null)
        {
            popUpRenderer = popUp.GetComponent<SpriteRenderer>();
        }

        foreach (SpriteRenderer sr in buttonRenderers)
        {
            sr.enabled = false;
        }

        // Ensure the popUp is not visible at the start
        if (popUpRenderer != null)
        {
            popUpRenderer.enabled = false;
        }
    }

    void Update()
    {
        // Check if the mouse is over the resume button
        bool isMouseOverResumeButton = resumeCollider.bounds.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetKeyDown(KeyCode.Escape) && !isMouseOverResumeButton)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        foreach (SpriteRenderer sr in buttonRenderers)
        {
            sr.enabled = isPaused;
        }

        // Toggle the popUp visibility
        if (popUpRenderer != null)
        {
            popUpRenderer.enabled = isPaused;
        }
    }


    private void SetButtonPositions()
    {
        Vector3 menuPosition = transform.position;
        Vector3 resumePosition = new Vector3(0f, -40f, 0f);
        Vector3 settingsPosition = new Vector3(90f, 0f, 0f);
        Vector3 restartPosition = new Vector3(-90f, 0f, 0f);
        

        transform.position = menuPosition;
        transform.Find("ResumeButton").transform.localPosition = resumePosition;
        transform.Find("SettingsButton").transform.localPosition = settingsPosition;
        transform.Find("RestartButton").transform.localPosition = restartPosition;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        foreach (SpriteRenderer sr in buttonRenderers)
        {
            sr.enabled = false;
        }

        // Ensure the popUp is not visible when game is resumed
        if (popUpRenderer != null)
        {
            popUpRenderer.enabled = false;
        }
    }
}
