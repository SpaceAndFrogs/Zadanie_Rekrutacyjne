using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestinationSetter : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private UnitSelectButtonHandler buttonHandler;
    [SerializeField]
    private UnitsCreator unitsCreator;
    private const int mouseButtonIndex = 0;
    private void Update()
    {
        CheckForPoint();
    }

    private void CheckForPoint()
    {
        if (Input.GetMouseButtonDown(mouseButtonIndex))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                DesignateDestination(hit.point);
            }
        }
    }

    private void DesignateDestination(Vector3 destination)
    {
        List<Unit> units = unitsCreator.CreatedUnits;
        int indexOfChoosenUnit = buttonHandler.IndexOfSelectedUnit;
        for (int i = 0; i < units.Count; i++)
        {
            if (indexOfChoosenUnit == i)
            {
                units[i].SetDestination(destination);
            }
            else
            {
                units[i].FollowTarget(units[indexOfChoosenUnit].transform);
            }
        }
    }
}
