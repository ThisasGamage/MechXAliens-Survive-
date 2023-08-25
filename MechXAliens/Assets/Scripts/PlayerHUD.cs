using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private ProgressBar healthbar;

    public void UpdateHealth( int currentHealth, int maxHealth)
    {
        healthbar.SetValues(currentHealth, maxHealth);
    }
}
