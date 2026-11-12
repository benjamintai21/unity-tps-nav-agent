using UnityEngine;

public enum KeyColor
{
    None,
    Red,
    Blue,
    Green,
    Yellow
}

public static class KeyColorHelper
{
    public static Color ToUnityColor(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red: return Color.red;
            case KeyColor.Blue: return Color.blue;
            case KeyColor.Green: return Color.green;
            case KeyColor.Yellow: return Color.yellow;
            default: return Color.white;
        }
    }
}

public class PlayerKeyInventory : MonoBehaviour
{
    [SerializeField] private KeyColor currentKey = KeyColor.None;
    private int doorsOpened = 0;

    public bool HasKey => currentKey != KeyColor.None;
    public KeyColor CurrentKey => currentKey;
    public int DoorsOpened => doorsOpened;

    public bool TryPickupKey(KeyColor newKey)
    {
        if (HasKey) return false;

        currentKey = newKey;
        return true;
    }

    public bool HasSpecificKey(KeyColor requiredColor)
    {
        return currentKey == requiredColor;
    }

    public void UseKey()
    {
        currentKey = KeyColor.None;
    }

    public void IncrementDoorsOpened()
    {
        doorsOpened++;
    }
}