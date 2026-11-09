using UnityEngine;

public class BgMovement : MonoBehaviour
{
    bool movement;

    [SerializeField] float movementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 2.35 && movement)
        {
            transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
        }
        else if (transform.position.x >= -2.35 && !movement)
        {
            transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
        }
        else
        {
            movement = !movement;
        }
    }
}
