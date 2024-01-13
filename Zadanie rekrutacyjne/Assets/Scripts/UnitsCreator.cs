using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitsCreator : MonoBehaviour
{
    [SerializeField]
    private int amountOfUnits;
    [SerializeField]
    private int minAmountOfUnits;
    [SerializeField]
    private int maxAmountOfUnits;
    [SerializeField]
    private TextMeshProUGUI unitsCounter;
    [SerializeField]
    private Button decreaseAmountButton;
    [SerializeField]
    private Button increaseAmountButton;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private UnitSelectButtonHandler buttonHandler;
    [SerializeField]
    private Unit unitPrefab;
    private List<Unit> createdUnits = new List<Unit>();
    public List<Unit> CreatedUnits
    {
        get {return createdUnits;} 
    }
    [SerializeField]
    private Transform spawnPointTransform;
    private void Start()
    {
        decreaseAmountButton.onClick.AddListener(DecreaseAmount);
        increaseAmountButton.onClick.AddListener(IncreaseAmount);
        confirmButton.onClick.AddListener(Confirm);
        unitsCounter.text = amountOfUnits.ToString();
    }

    private void Confirm()
    {
        CreateUnits();
    }

    private void DecreaseAmount()
    {
        if(amountOfUnits>minAmountOfUnits)
        {
            amountOfUnits--;
            unitsCounter.text = amountOfUnits.ToString();
        }
    }

    private void IncreaseAmount()
    {
        if (amountOfUnits < maxAmountOfUnits)
        {
            amountOfUnits++;
            unitsCounter.text = amountOfUnits.ToString();
        }
    }

    private void CreateUnits()
    {
        for(int i = 0; i < amountOfUnits; i++)
        {
            Unit spawnedUnit = Instantiate(unitPrefab, spawnPointTransform.position, transform.rotation);
            createdUnits.Add(spawnedUnit);
        }
        buttonHandler.CreateButtons(amountOfUnits);
    }
}
