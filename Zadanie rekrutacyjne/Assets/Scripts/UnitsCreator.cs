using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitsCreator : MonoBehaviour
{
    [SerializeField]
    private int amountOfUnits;
    private int minAmountOfUnits;
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
    private List<Unit> createdUnits;
    public List<Unit> CreatedUnits
    {
        get {return createdUnits;} 
    }
    [SerializeField]
    private Transform spawnPointTransform;
    private void Start()
    {

    }

    private void Confirm()
    {

    }

    private void DecreaseAmount()
    {

    }

    private void IncreaseAmount()
    {

    }

    private void CreateUnits()
    {

    }
}
