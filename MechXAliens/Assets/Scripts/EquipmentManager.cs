using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquippedWeapon = 1;
    public GameObject currentWeaponObject = null;
    public Transform currentWeaponBarrel = null;

    public Transform WeaponHolderR = null;
    private Animator anim;
    private Inventory inventory;

    [SerializeField] Weapon defaultWeapon = null;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquippedWeapon !=0)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(0));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquippedWeapon != 0)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(1));
        }
    }


    private void EquipWeapon(Weapon weapon)
    {
        currentlyEquippedWeapon = (int)weapon.weaponStyle;
        anim.SetInteger("weaponType", (int)weapon.weaponType);
    }

    private void UnequipWeapon()
    {
        anim.SetTrigger("unequipWeapon");
    }

    private void InitVariables()
    {
        inventory.AddItem(defaultWeapon);
        EquipWeapon(inventory.GetItem(0));
    }

    private void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }
}
