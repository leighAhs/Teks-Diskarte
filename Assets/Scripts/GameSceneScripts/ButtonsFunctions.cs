using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] GameObject teks;
    GameController gameController;
    GameObject controller;
    GameObject enemyTeksDeck;
    private void Start()
    {
        controller = GameObject.Find("GameController");
        gameController = controller.GetComponent<GameController>();

        enemyTeksDeck = GameObject.Find("EnemyTeksCards");
    }
    public void OnSwitchButtonClick()
    {
        gameController.playerTeksActiveIndex++;
    }

    public void OnDropButtonClick()
    {
        if (teks.transform.childCount != 0)
        {
            for (int i = 0; i < teks.transform.childCount; i++)
            {
                GameObject child = teks.transform.GetChild(i).gameObject;

                if (child.activeSelf)
                {
                    child.name = "PlayerTeks";
                    child.transform.SetParent(null);
                    Teks.playerOnDrop = true;
                }
            }
        }

        StartCoroutine(enemyPickRandomCard());

    }
    IEnumerator enemyPickRandomCard()
    {
        int random = Random.Range(1, 6);
        if (enemyTeksDeck.transform.childCount != 0)
        {
            Debug.Log("The random Time is: " + random);

            yield return new WaitForSeconds(random);
            int randomEnemyTeks = Random.Range(0, enemyTeksDeck.transform.childCount);

            GameObject child = enemyTeksDeck.transform.GetChild(randomEnemyTeks).gameObject;

            child.transform.SetParent(null);
            child.name = "EnemyTeks";

            GameController.enemyIsDropping = true;
        }
    }
}
