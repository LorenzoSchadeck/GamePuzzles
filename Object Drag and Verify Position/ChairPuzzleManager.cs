using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPuzzleManager : MonoBehaviour
{
    public GameObject chair1;
    public GameObject chair2;
    public GameObject chair3;

    private void Update()
    {
        if (AreChairsInCorrectPosition())
        {      
            Debug.Log("Cadeiras na posição correta!");
        }
    }

    private bool AreChairsInCorrectPosition()
    {
        return chair1.transform.position == new Vector3(0f, 1f, 3f)
            && chair2.transform.position == new Vector3(3f, 1f, 3f)
            && chair3.transform.position == new Vector3(-3f, 1f, 3f);
    }
}
