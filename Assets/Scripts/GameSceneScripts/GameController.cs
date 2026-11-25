using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] public int playerTeksActiveIndex = 0;
    [SerializeField] public static int enemyTeksActiveIndex = 0;
    [SerializeField] public static int totalOnhandTeks;
    int firstThrower;

    [SerializeField] GameObject playerTeksDeck;
    [SerializeField] GameObject enemyTeksDeck;

    GameObject playerTeks;
    GameObject enemyTeks;

    public static bool playerTurn;
    public static bool enemyTurn;
    public static bool enemyIsDropping;

    GameObject buttonObject;
    Button button;


    GameObject enemyDropTeksPosition;

    Teks playerTeksScript;

    [SerializeField] TextMeshProUGUI currentCardData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        buttonObject = GameObject.Find("Button");
        button = buttonObject.GetComponent<Button>();
        enemyDropTeksPosition = GameObject.Find("EnemyDropTeksPosition");

        totalOnhandTeks = playerTeksDeck.transform.childCount;

        startingCard();

        firstToThrowCard();
    }

    // Update is called once per frame
    private void Update()
    {
        int randomNum = UnityEngine.Random.Range(1, 3);
        firstThrower = randomNum;

        playerTeks = GameObject.Find("PlayerTeks");


        playerCardSwitching();

        if (playerTeks)
        {
            if (playerTeks.transform.position == GameObject.Find("PlayerDropTeksPosition").transform.position)
            {
                playerTurn = false;
                button.enabled = false;
                enemyTurn = true;
            }
        }

        if (enemyIsDropping)
        {
            enemyDropTeks();
        }

    }

    void firstToThrowCard()
    {
        int firstDrop = UnityEngine.Random.Range(1, 3);
        int num = 2;
        if (num == 1)
        {
            playerTurn = true;
            button.enabled = true;
            enemyTurn = false;
        }
        else if (num == 2)
        {

            int randomEnemyTeks = UnityEngine.Random.Range(0, enemyTeksDeck.transform.childCount);

            GameObject child = enemyTeksDeck.transform.GetChild(randomEnemyTeks).gameObject;

            child.transform.SetParent(null);
            child.name = "EnemyTeks";

            button.enabled = false;
            playerTurn = false;
            enemyIsDropping = true;
        }
    }

    void startingCard()
    {
        for (int i = 0; i < playerTeksDeck.transform.childCount; i++)
        {
            playerTeksDeck.transform.GetChild(i).gameObject.SetActive(false);

        }
        playerTeksDeck.transform.GetChild(0).gameObject.SetActive(true);
    }

    void playerCardSwitching()
    {
        if (playerTeksActiveIndex >= playerTeksDeck.transform.childCount)
        {
            if (playerTeksDeck.transform.childCount != 0)
            {
                totalOnhandTeks = playerTeksDeck.transform.childCount;
                playerTeksActiveIndex = 0;
                playerTeksDeck.transform.GetChild(playerTeksActiveIndex).gameObject.SetActive(true);
                playerTeksDeck.transform.GetChild(playerTeksDeck.transform.childCount - 1).gameObject.SetActive(false);
            }

        }

        for (int i = 0; i < playerTeksDeck.transform.childCount; i++)
        {
            GameObject child = playerTeksDeck.transform.GetChild(i).gameObject;

            if (child.activeSelf)
            {
                child.SetActive(false);
            }
            playerTeksDeck.transform.GetChild(playerTeksActiveIndex).gameObject.SetActive(true);

            playerTeksScript = playerTeksDeck.transform.GetChild(playerTeksActiveIndex).GetComponent<Teks>();

            if(playerTeksDeck.transform.childCount != 0)
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

            currentCardData.text = $"{rarity} - {ability} - {abilityCount}";
            }
            
        }
    }

    void enemyDropTeks()
    {
        enemyTeks = GameObject.Find("EnemyTeks");
        playerTeks = GameObject.Find("PlayerTeks");

        if (enemyTeks != null)
        {
            enemyTeks.transform.position = Vector3.MoveTowards(enemyTeks.transform.position, enemyDropTeksPosition.transform.position, 4f * Time.deltaTime);
        }

        if (enemyTeks && enemyTeks.transform.position == enemyDropTeksPosition.transform.position)
        {
            if (enemyTeks != null)
            {
                button.enabled = true;
                playerTurn = true;
                enemyIsDropping = false;
            }

            Destroy(enemyTeks, 0.3f);
        }
    }

    void gameData()
    {
        string bot = GameSceneSetting.data.gamePlayerData[0].name;
        string player = GameSceneSetting.data.gamePlayerData[1].name;

        if (bot != null)
        {
            GameSceneSetting.data.gamePlayerData[0].currentTotalCards = enemyTeksDeck.transform.childCount;
        }

        if (player != null)
        {
            GameSceneSetting.data.gamePlayerData[0].currentTotalCards = playerTeksDeck.transform.childCount;
        }

        
    }
}
