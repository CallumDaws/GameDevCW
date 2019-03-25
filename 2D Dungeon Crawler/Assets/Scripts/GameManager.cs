using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ManaBar manaBar;
    public Player player;
    private float health;
    private float mana;
    public TextMeshProUGUI text;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI healthpots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyText.SetText(player.playerInventory.keys.ToString());
        coinText.SetText(player.playerInventory.coins.ToString());
        healthpots.SetText(player.playerInventory.HealthPots.ToString());
        text.SetText(player.health.ToString());
        manaText.SetText(player.mana.ToString());
        health = (float)player.health/100;
        mana = (float)player.mana / 100;
        healthBar.SetSize(health);
        manaBar.SetSize(mana);
    }
}
