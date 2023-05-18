using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    public Transform characterTransform;
    private TMP_Text textMeshPro;
    private Player1NameInput player1NameInput;
    private Player2NameInput player2NameInput;

    private void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();

        if (gameObject.CompareTag("Player1"))
        {
            player1NameInput = FindObjectOfType<Player1NameInput>();
        }
        else if (gameObject.CompareTag("Player2"))
        {
            player2NameInput = FindObjectOfType<Player2NameInput>();
        }

        transform.SetParent(characterTransform);
        transform.localPosition = Vector3.up * 3;
    }

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;

        if (gameObject.CompareTag("Player1"))
        {
            textMeshPro.text = player1NameInput != null ? player1NameInput.PlayerName : "";
        }
        else if (gameObject.CompareTag("Player2"))
        {
            textMeshPro.text = player2NameInput != null ? player2NameInput.PlayerName : "";
        }
    }
}
