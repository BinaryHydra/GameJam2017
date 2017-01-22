using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int maxPlayerHealth;
    private int currentPlayerHealth;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("Player Hit!");
            currentPlayerHealth--;
            Destroy(collision.gameObject, 0.001f);
            if (currentPlayerHealth == 0) Destroy(gameObject, 0.001f);
        }
    }

}
