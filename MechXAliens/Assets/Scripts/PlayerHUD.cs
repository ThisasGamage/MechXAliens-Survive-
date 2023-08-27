using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public static PlayerHUD instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] private ProgressBar healthbar;
    [SerializeField] private WeaponUI weaponUI;
    [SerializeField] private Score scoreUI;

    public void UpdateHealth( int currentHealth, int maxHealth)
    {
        healthbar.SetValues(currentHealth, maxHealth);
    }

    public void UpdateWeaponUI(Weapon newWeapon)
    {
        weaponUI.UpdateInfo(newWeapon.icon, newWeapon.magazineSize, newWeapon.storedAmmo);
    }

    public void UpdateWeaponAmmoUI(int currentAmmo, int storedAmmo) 
    {
        weaponUI.UpdateAmmoUI(currentAmmo, storedAmmo);
    }

    public void UpdateScoreAmount()
    {
        scoreUI.AddToScore();
    }
}
