using System;
using Unity.VisualScripting;
using UnityEngine;

public class Teks : MonoBehaviour
{
    Animator anim;

    GameObject target;

    public static bool onDrop;

    [Header("Teks Properties")]
    [SerializeField] public string rarity;
    [SerializeField] public string ability;
    [SerializeField] public int attackCount;
    [SerializeField] public int blockCOunt;
    [SerializeField] public int addLifeCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("PlayerDropTeksPosition");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("onDrop: " + onDrop);
        if (target != null && onDrop)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.transform.position,
                1f * Time.deltaTime
            );
        }

        if(transform.position == target.transform.position)
        {
            onDrop = false;
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
        Destroy(gameObject);    
    }
}
