using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;

    private Camera cam;
    private Inventory inventory;
    private PlayerStats stats;
    private WeaponShooting shooting;
    private EquipmentManager equipment;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3 (Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            //Raycast
            if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                Debug.Log("Hit:" + hit.transform.name);
                if(hit.transform.GetComponent<ItemObject>().item as Weapon)
                {
                    Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                    inventory.AddItem(newItem);
                }
                else
                {
                    Consumable newItem = hit.transform.GetComponent<ItemObject>().item as Consumable;
                    if(newItem.type == ConsumbleType.Medkit)
                    {
                        stats.Heal(stats.GetMaxHealth());
                    }
                    else
                    {
                        if (inventory.GetItem(0) != null)
                            shooting.AddAmmo(0, inventory.GetItem(0).magazineSize, inventory.GetItem(0).storedAmmo);
                        if (inventory.GetItem(1) != null)
                            shooting.AddAmmo(1, inventory.GetItem(1).magazineSize, inventory.GetItem(1).storedAmmo);
                    }
                }

                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
        shooting = GetComponent<WeaponShooting>();
        equipment = GetComponent<EquipmentManager>();
    }
}
