using Unity.VisualScripting;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] GameObject teks;
    GameController gameController;
    GameObject controller;  
    private void Start()
    {
        controller = GameObject.Find("GameController");
        gameController = controller.GetComponent<GameController>();
    }
    public void OnSwitchButtonClick()
    {
        gameController.teksActiveIndex++;
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
                    child.transform.SetParent(null);
                    Debug.Log("asd");
                    Teks.onDrop = true;
                }
            }
        }
    }
}
