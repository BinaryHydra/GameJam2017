using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int maxPlayerHealth;
    private int currentPlayerHealth;
    public GameObject hearth1;
    public GameObject hearth2;
    public GameObject hearth3;
    public GameObject hearth4;
    public GameObject hearth5;
    public Sprite deadSprite;
    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("Player Hit!");
            ReplaceHearth(currentPlayerHealth);
            currentPlayerHealth--;
            Destroy(collision.gameObject, 0.001f);
            if (currentPlayerHealth == 0) Destroy(gameObject, 0.001f);

        }
    }

    private void ReplaceHearth(int i)
    {
        switch(i)
        {
            case 1:
                hearth1.GetComponent<SpriteRenderer>().sprite = deadSprite;
                break;
            case 2:
                hearth2.GetComponent<SpriteRenderer>().sprite = deadSprite;
                break;
            case 3:
                hearth3.GetComponent<SpriteRenderer>().sprite = deadSprite;
                break;
            case 4:
                hearth4.GetComponent<SpriteRenderer>().sprite = deadSprite;
                break;
            case 5:
                hearth5.GetComponent<SpriteRenderer>().sprite = deadSprite;
                break;
        }
    }

}
