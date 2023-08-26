using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private WeaponShooting shooting;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;

        shooting.initAmmo((int)newItem.weaponStyle, newItem);
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index) 
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[2];
    }

    private void GetReferences()
    {
        shooting = GetComponent<WeaponShooting>();
    }
}
