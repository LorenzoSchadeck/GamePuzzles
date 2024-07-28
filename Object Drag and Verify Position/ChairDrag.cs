using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private float groundHeight = 2.45f;
    private float initialDistanceFromCamera;

    private void OnMouseDown()
    {
        if (IsPlayerInRange())
        {
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Se a cadeira estiver perto o suficiente da posição correta, ajuste para a posição correta
        if (IsChairNearCorrectPosition())
        {
            transform.position = RoundToCorrectPosition(transform.position);
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, initialDistanceFromCamera);
            Vector3 cursorWorldPoint = Camera.main.ScreenToWorldPoint(cursorScreenPoint);


            cursorWorldPoint.y = Mathf.Max(cursorWorldPoint.y, groundHeight);
            transform.position = cursorWorldPoint + offset;
        }
    }

    private bool IsPlayerInRange()
    {
        Vector3 playerPosition = Camera.main.transform.position;
        Vector3 chairPosition = transform.position;

        float distance = Vector3.Distance(playerPosition, chairPosition);

        return distance <= 3f;
    }

    private bool IsChairNearCorrectPosition()
    {
        Vector3 correctPosition = new Vector3(0f, 1f, 3f);
        float distance = Vector3.Distance(transform.position, correctPosition);
        return distance <= 1f;
    }

    private Vector3 RoundToCorrectPosition(Vector3 position)
    {
        return new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.z));
    }
}
