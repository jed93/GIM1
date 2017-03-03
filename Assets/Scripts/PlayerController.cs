using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public Text scoreText;
  public Text winText;

  private Rigidbody rb;
  private int score;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    SetScore(0);
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
    rb.AddForce(movement * speed);
  }

  void OnTriggerEnter(Collider other)
  {

		if (other.gameObject.CompareTag("Pickup"))
    {
      other.gameObject.SetActive(false);
      SetScore(score + 1);
    }
		else if (other.gameObject.CompareTag("Pickup_Sphere"))
		{
			other.gameObject.SetActive(false);
			SetScore(score + 2);
		}
  }

  private void SetScore(int newScore)
  {
    score = newScore;
    scoreText.text = "Score: " + score.ToString();
    winText.text = score < 10 ? "" : "You win!";
  }
}
