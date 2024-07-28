using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RuneDoor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject rune_door;
    [SerializeField] private Rune runeScript;

    private bool isOpen = false;

    private void Update()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        if (!isOpen)
        {
            if (AreAllRunesActive())
            {
                rune_door.transform.Rotate(0f, 90f, 0f);
                isOpen = true;
            }
        }
    }

    private bool AreAllRunesActive()
    {
        foreach (bool isActive in runeScript.runeStates)
        {
            if (!isActive)
            {
                return false;
            }
        }
        return true;
    }
}
