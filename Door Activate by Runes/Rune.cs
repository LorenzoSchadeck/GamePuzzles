using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private float activationRange = 3f;

    [Header("Runes")]
    [SerializeField] private GameObject[] runes;

    public bool[] runeStates;

    void Start()
    {
        // Initialize the rune states array based on the number of runes
        runeStates = new bool[runes.Length];
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= activationRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActivateNextRune();
            }
        }
    }

    void ActivateNextRune()
    {
        for (int i = 0; i < runeStates.Length; i++)
        {
            if (!runeStates[i])
            {
                runeStates[i] = true;
                // Add additional logic to handle rune activation, e.g., enable the rune GameObject
                runes[i].SetActive(true);
                break;
            }
        }
    }
}