using System;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int PlayerHealth = 10;
    public static int EnemyHealth = 10;

    GameObject playerTeks;
    GameObject enemyTeks;

    Teks playerTeksScript;
    Teks enemyTeksScript;

    [SerializeField] TextMeshProUGUI playerLife;
    [SerializeField] TextMeshProUGUI enemyLife;


    [Header("Player Teks Data")]
    [SerializeField] TextMeshProUGUI playerCardRarity;
    [SerializeField] TextMeshProUGUI playerTeksAbility;
    [SerializeField] TextMeshProUGUI playerTeksAbilityCount;

    [Header("Enemy Teks Data")]
    [SerializeField] TextMeshProUGUI enemyCardRarity;
    [SerializeField] TextMeshProUGUI enemyTeksAbility;
    [SerializeField] TextMeshProUGUI enemyTeksAbilityCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLife.text = PlayerHealth.ToString();
        enemyLife.text = EnemyHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTeksDataChecker();
        EnemyTeksDataChecker();
    }

    void PlayerTeksDataChecker()
    {
        playerTeks = GameObject.Find("PlayerTeks");


        if (playerTeks != null)
        {
            playerTeksScript = playerTeks.GetComponent<Teks>();
        }
        


        if(playerTeks != null)
        {
            string rarity = playerTeksScript.rarity;
            string ability = playerTeksScript.ability;
            int abilityCount = 0;

            if (ability.Contains("attack", StringComparison.OrdinalIgnoreCase))
            {
                abilityCount = playerTeksScript.attackCount;
            }
            else if (ability.Contains("block", StringComparison.OrdinalIgnoreCase))
            {
                abilityCount = playerTeksScript.blockCount;

            }
            else if (ability.Contains("heal", StringComparison.OrdinalIgnoreCase))
            {
                abilityCount = playerTeksScript.addLifeCount;
            }

            playerCardRarity.text = rarity;
            playerTeksAbility.text = ability;
            playerTeksAbilityCount.text = abilityCount.ToString();
        }
    }

    void EnemyTeksDataChecker()
    {
        enemyTeks = GameObject.Find("EnemyTeks");

        if (enemyTeks != null)
        {
            enemyTeksScript = enemyTeks.GetComponent<Teks>();
        }

        string rarity = enemyTeksScript.rarity;
        string ability = enemyTeksScript.ability;
        int abilityCount = 0;

        if (enemyTeks != null)
        {
            if (ability.Contains("Attack", StringComparison.OrdinalIgnoreCase))
            {
                abilityCount = enemyTeksScript.attackCount;
            }
            else if (ability.Contains("Block", StringComparison.OrdinalIgnoreCase))
            {
                abilityCount = enemyTeksScript.blockCount;

            }
            else if (ability.Contains("Heal", StringComparison.OrdinalIgnoreCase))
            {
                abilityCount = enemyTeksScript.addLifeCount;
            }
        }

        enemyCardRarity.text = rarity;
        enemyTeksAbility.text = ability;
        enemyTeksAbilityCount.text = abilityCount.ToString();
    }
}
