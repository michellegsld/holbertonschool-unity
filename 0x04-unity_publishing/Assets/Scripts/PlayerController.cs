using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 5;
    private int score = 0;
    public Text scoreText;
    public Text healthText;
    public Image winloseBG;
    public Text winloseText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed = 15f * Time.deltaTime;

        if (health == 0)
        {
            //Debug.Log("Game Over!");
            winloseBG.color = Color.red;
            winloseText.color = Color.white;
            winloseText.text = "Game Over!";
            winloseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.z += speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x -= speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.z -= speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x += speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    // Increment the value of score when the Player touches the Pickup tag
    // Decrement the value of health when the Player touches the Trap tag
    // Ends the game when the Player touches the Goal tag
    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Pickup")
        {
            score++;
            //Debug.Log("Score: " + score);
            SetScoreText();
            Destroy(other.gameObject);
        }
        else if (tag == "Trap")
        {
            health--;
            //Debug.Log("Health: " + health);
            SetHealthText();
        }
        else if (tag == "Goal")
        {
            //Debug.Log("You win!");
            winloseBG.color = Color.green;
            winloseText.color = Color.black;
            winloseText.text = "You Win!";
            winloseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }

    // Updates the score text UI
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Updates the heath text UI
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // Waits a couple seconds before reloading the scene
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
