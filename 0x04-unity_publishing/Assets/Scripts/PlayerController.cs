using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private int score = 0;

    public int health = 5;

    public Text scoreText;

    public Text healthText;

    private Text WinLoseText;

    public Image WinLoseBG;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        WinLoseText = WinLoseBG.GetComponentInChildren<Text>();
        WinLoseBG.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float hori_movement = Input.GetAxis("Horizontal");
        float verti_movement = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(hori_movement, 0.0f, verti_movement);

        rb.AddForce(force * speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    void SetWinText()
    {
        WinLoseBG.color = Color.green;
        WinLoseText.text = "You Win!";
        WinLoseText.color = Color.black;
        WinLoseBG.enabled = true;
    }

    void SetLoseText()
    {
        WinLoseBG.color = Color.red;
        WinLoseText.text = "Game Over!";
        WinLoseText.color = Color.white;
        WinLoseBG.enabled = true;
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }

    void FixedUpdate()
    {
        if (health == 0)
        {
            SetLoseText();
            StartCoroutine(LoadScene(3));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            ++score;
            SetScoreText();
            //Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            --health;
            SetHealthText();
            //Debug.Log($"Health: {health}");


        }
        else if (other.CompareTag("Goal"))
        {
            SetWinText();
            StartCoroutine(LoadScene(3));
            //Debug.Log("You win!");
        }
    }
}
