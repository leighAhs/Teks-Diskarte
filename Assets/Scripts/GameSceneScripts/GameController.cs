using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public int teksActiveIndex = 0;
    [SerializeField] public static int totalOnhandTeks;

    [SerializeField] GameObject teks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalOnhandTeks = teks.transform.childCount;
        for (int i = 0; i < teks.transform.childCount; i++)
        {
            teks.transform.GetChild(i).gameObject.SetActive(false);

        }
        teks.transform.GetChild(0).gameObject.SetActive(true);

        //for (int i = 0; i < teks.transform.childCount; i++)
        //{
        //    GameObject child = teks.transform.GetChild(i).gameObject;

        //    if (child.activeSelf)
        //    {
        //        Debug.Log("Active child: " + child.name);
        //    }
        //}   
    }

    // Update is called once per frame
    private void Update()
    {
        if(teksActiveIndex >= teks.transform.childCount)
        {
            totalOnhandTeks = teks.transform.childCount;
            teksActiveIndex = 0;
            teks.transform.GetChild(teksActiveIndex).gameObject.SetActive(true);
            teks.transform.GetChild(teks.transform.childCount - 1).gameObject.SetActive(false);
        }

        for (int i = 0; i < teks.transform.childCount; i++)
        {
            GameObject child = teks.transform.GetChild(i).gameObject;

            if (child.activeSelf)
            {
                child.SetActive(false);
            }
            teks.transform.GetChild(teksActiveIndex).gameObject.SetActive(true);
        }
    }

    
}
