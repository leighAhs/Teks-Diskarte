using UnityEngine;
using UnityEngine.UI;

public class Teks : MonoBehaviour
{
    Animator anim;

    GameObject playerDropTeksPosition;

    public static bool playerOnDrop;
    public static bool enemyOnDrop;

    [Header("Teks Properties")]
    [SerializeField] public string rarity;
    [SerializeField] public string ability;
    [SerializeField] public int attackCount;
    [SerializeField] public int blockCount;
    [SerializeField] public int addLifeCount;

    GameObject buttonObject;
    Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        playerDropTeksPosition = GameObject.Find("PlayerDropTeksPosition");

        buttonObject = GameObject.Find("Button");
        button = buttonObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name == "PlayerTeks")
        {
            if (playerDropTeksPosition != null && playerOnDrop)
            {
                button.enabled = false;
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    playerDropTeksPosition.transform.position,
                    4f * Time.deltaTime
                );
            }
        }

        if (transform.position == playerDropTeksPosition.transform.position)
        {
            GameController.enemyTurn = true;
            playerOnDrop = false;
            Invoke("destroy", 3f);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse0 key pressed");
        anim.Play("TeksRotation");
    }

    void destroy()
    {
        button.enabled = true;
        Destroy(gameObject);
    }
}
