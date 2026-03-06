
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public PlayerShip player;
    public float parallaxEffect;

    public float scrollSpeed;
    private float currentDeltaPosition = 0;

    private float length = 0;

    public float minimumPlayerPosition = -2.15f;

    public float maximumPlayerPosition = 13.85f;

    public float playerSpeedInfluence = 5;

    Vector3 startingPlayerPosition = Vector3.zero;

    Vector3 playerOffset = Vector3.zero;

    float playerOffsetx = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        startingPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentDeltaPosition = scrollSpeed * Time.deltaTime;

        if (player != null)
        {
            playerOffset = player.transform.position - startingPlayerPosition;

            playerOffsetx = player.deltaPositionx * Time.deltaTime * playerSpeedInfluence;
        }

        float xValue = transform.position.x - (currentDeltaPosition + playerOffsetx) * parallaxEffect;

        transform.position = new Vector3(xValue, transform.position.y, transform.position.z);

        if (scolledOutOfView())
        {
            teleportBack();
        }

    }

    private bool scolledOutOfView()
    {
        return transform.position.x < -21;
    }

    private void teleportBack()
    {
        transform.position = new Vector3(transform.position.x + 3 * length, transform.position.y, transform.position.z);

        currentDeltaPosition = 0;
    }
}
