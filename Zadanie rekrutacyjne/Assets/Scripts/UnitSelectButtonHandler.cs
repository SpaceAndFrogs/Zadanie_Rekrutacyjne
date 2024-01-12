using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelectButtonHandler : MonoBehaviour
{
    [SerializeField]
    private Button buttonPrefab;
    private List<Button> unitsButtons = new List<Button>();
    private int indexOfSelectedUnit = 0;
    public int IndexOfSelectedUnit
    {
        get { return indexOfSelectedUnit; }
    }

    private void AddListenersToButtons()
    {
        for (int i = 0; i < unitsButtons.Count; i++)
        {
            int index = i;
            unitsButtons[i].onClick.AddListener(() => ChooseUnit(index));
            unitsButtons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }

    private void ChooseUnit(int indexOfUnit)
    {
        indexOfSelectedUnit = indexOfUnit;
        Debug.Log("Choosen unit " + indexOfUnit);
    }

    public void CreateButtons(int amountOfUnits)
    {
        for (int i = 0; i < amountOfUnits; i++)
        {
            Button spawnedButton = Instantiate(buttonPrefab, transform);
            unitsButtons.Add(spawnedButton);
        }
        AddListenersToButtons();
    }
}
