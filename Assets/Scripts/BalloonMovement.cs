using UnityEngine;
using UnityEngine.SceneManagement;
public class FloatingBalloon : MonoBehaviour
{
    public float changeTime = 2f;
    public float growthRate = 0.1f;
    private float timer;
    private float growthTimer;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private float speed;
    [SerializeField] private AudioSource timerEndSound;

    public Vector2 minBounds;  // Lower-left corner of the movement area
    public Vector2 maxBounds;  // Upper-right corner of the movement area

    void Start()
    {
        SetSpeedBasedOnLevel();
        rb2d = GetComponent<Rigidbody2D>();
        ChangeDirection();
        Destroy(gameObject, 10f);  // Destroy the balloon after 10 seconds
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeTime)
        {
            ChangeDirection();
            timer = 0;
        }
        MoveBalloon();

        growthTimer += Time.deltaTime;
        if (growthTimer >= 1f)
        {
            GrowBalloon();
            growthTimer = 0;
        }
    }

    void ChangeDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        movement = new Vector2(randomX, randomY).normalized;
    }

    void MoveBalloon()
    {
        Vector2 newPosition = rb2d.position + movement * speed * Time.fixedDeltaTime;

        // Check and reverse direction if hitting horizontal bounds
        if (newPosition.x <= minBounds.x || newPosition.x >= maxBounds.x)
        {
            movement.x = -movement.x;
        }

        // Check and reverse direction if hitting vertical bounds
        if (newPosition.y <= minBounds.y || newPosition.y >= maxBounds.y)
        {
            movement.y = -movement.y;
        }

        // Recalculate newPosition with new movement direction
        newPosition = rb2d.position + movement * speed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        rb2d.MovePosition(newPosition);
    }



    void GrowBalloon()
    {
        transform.localScale += new Vector3(growthRate, growthRate, growthRate);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slash"))
        {
            GameManager.Instance.BalloonPopped();
            PersistentData.Instance.SetScore(PersistentData.Instance.GetScore() + 1);
            Debug.Log("Balloon popped. Score: " + PersistentData.Instance.GetScore());
            
        }
    }


    void SetSpeedBasedOnLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "Level1":
                speed = 3f;// speed for Level1
                break;
            case "Level2":
                speed = 7f;// seed for Level2
                break;
            case "Level3":
                speed = 10f;  // speed for Level3
                break;
               
        }
        Debug.Log("Balloon Speed Set To: " + speed);

    }


}
