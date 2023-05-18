using UnityEngine;
using TMPro;

public class ColorPicker1 : MonoBehaviour
{
    public SpriteChanger1 characterSpriteChanger; // Reference to the SpriteChanger1 script attached to the character

    private TMP_Dropdown colorDropdown; // Reference to the TMPro dropdown menu

    private void Start()
    {
        colorDropdown = GetComponent<TMP_Dropdown>(); // Get the TMP_Dropdown component attached to the same GameObject
        colorDropdown.onValueChanged.AddListener(OnColorDropdownValueChanged);
    }

    private void OnColorDropdownValueChanged(int colorIndex)
    {
        characterSpriteChanger.ChangeCharacterSprite(colorIndex);
    }
}
