using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private EquipmentManager manager;
    private Inventory inventory;

    public void Start()
    {
        GetReferences();
    }

    public void DestroyWeapon()
    {
        Destroy(manager.currentWeaponObject);
    }

    public void InstantiateWeapon()
    {
        manager.currentWeaponObject = Instantiate(inventory.GetItem(manager.currentlyEquippedWeapon).prefab, manager.WeaponHolderR);
        manager.currentWeaponBarrel = manager.currentWeaponObject.transform.GetChild(0);
    }

    public void StartReload()
    {

    }

    public void GetReferences()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
    }
}
