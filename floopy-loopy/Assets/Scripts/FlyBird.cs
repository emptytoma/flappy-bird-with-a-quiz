using UnityEngine;
 public class FlyBird : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb;
    public float velocity = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       gameManager.Fail();
       // Debug.Log(message: "You loooooose!");
       //Destroy(gameObject);

    }
}
