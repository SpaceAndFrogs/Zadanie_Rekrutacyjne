using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelectButtonHandler : MonoBehaviour
{
    [SerializeField]
    private Button buttonPrefab;
    private List<Button> unitsButtons;
    private int indexOfSelectedUnit = 0;
    public int IndexOfSelectedUnit
    {
        get { return indexOfSelectedUnit; }
    }

    private void AddListenersToButtons()
    {

    }

    private void ChooseUnit(int indexOfUnit)
    {

    }

    public void CreateButtons(int amountOfUnits)
    {

    }
}
