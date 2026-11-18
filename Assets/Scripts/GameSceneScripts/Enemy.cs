using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject playerTeks;

    [SerializeField] GameObject enemyTeks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        enemyTurn();
        Debug.Log("ENEMY SCRIPT; EnemyTurn: " + GameController.enemyTurn);
    }

    void enemyTurn()
    {
        if (GameController.enemyTurn)
        {
            if (enemyTeks.transform.childCount > 0)
            {
                int randomTeks = Random.Range(0, enemyTeks.transform.childCount);

                GameObject child = enemyTeks.transform.GetChild(randomTeks).gameObject;

                child.name = "EnemyTeks";
                child.transform.SetParent(null);

                Teks.enemyOnDrop = true;

                GameController.enemyTurn = false;
            }
        }
    }
}
