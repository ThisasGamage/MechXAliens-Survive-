using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject prefab;
    public int magazineSize;
    public int magazineCount;
    public float range;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;
}

public enum WeaponType { Pistol, AR, Shotgun, Sniper }
public enum WeaponStyle { Primary, Secondary }
