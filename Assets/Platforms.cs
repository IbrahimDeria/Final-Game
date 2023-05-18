using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private Collider2D col;
    private bool playerOn = false;  // Start with false since player is not initially grounded
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOn && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Check");
            col.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(2f);
        col.enabled = true;
    }

    private void setPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<Collider2D>();
        if (player != null && Physics2D.IsTouchingLayers(player, LayerMask.GetMask("Ground")))
        {
            playerOn = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        setPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        setPlayerOnPlatform(other, false);
    }
}
