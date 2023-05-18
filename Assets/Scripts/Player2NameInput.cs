using UnityEngine;
using TMPro;

public class Player2NameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public string PlayerName { get; private set; }

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onEndEdit.AddListener(SavePlayerName);
        PlayerName = "Player 2";
    }

    private void SavePlayerName(string input)
    {
        PlayerName = input;
    }
}
