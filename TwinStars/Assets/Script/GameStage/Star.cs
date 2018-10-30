using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	public Vector3 blue;
	public Vector3 red;

	int deathCount = 10;
    bool isInitialized = false;

    // Use this for initialization
    void Start () {
		GameState.isGamePaused = false;
        GameState.isGameOver = false;
        GameState.isGameClear = false;
        GetComponent<SpriteRenderer>().enabled = false;

        if (!GameState.saveData.tutorialShowing[GameState.StageLevel - 1]) {
            GetComponent<SpriteRenderer>().enabled = true;
            isInitialized = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		Debug.Log("RedStar " + red);
		Debug.Log("BlueStar " + blue);
		if (GameState.isGamePaused && Input.anyKey && !GameState.isGameOver && !GameState.isGameClear) {
			GameState.isGamePaused = false;
		}

		if (!isInitialized && !GameState.saveData.tutorialShowing[GameState.StageLevel - 1]) {
            GetComponent<SpriteRenderer>().enabled = true;
            isInitialized = true;
        }
        else if (!isInitialized) {
            return;
        }

        if (GameState.isGamePaused) return;
        float deltaTime = Time.deltaTime;
        const float speed = 5.0f;

        Vector2 moveDir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) moveDir.y += 1;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) moveDir.y -= 1;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) moveDir.x -= 1;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) moveDir.x += 1;

        moveDir.Normalize();
        
        moveDir = moveDir * speed * deltaTime;

        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + moveDir);
    }

    private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Bullet" && gameObject.name == "RedStar") {
			if (deathCount <= 0) {
				GetComponent<Animator>().SetBool("isShooted", true);
				GameObject.Find("BlueStar").GetComponent<Animator>().SetBool("isBlueExplode", true);
				GameState.isGameOver = true;	
			} else {
				GameObject.Find("RedStar").transform.position = red;
				GameObject.Find("BlueStar").transform.position = blue;
				deathCount--;
			}
			GameState.isGamePaused = true;
		}
		else if (other.gameObject.tag == "SavePoint") {
			red = GameObject.Find("RedStar").transform.position;
			blue = transform.position;
			Star s = GameObject.Find("RedStar").GetComponent<Star>();
			s.red = GameObject.Find("RedStar").transform.position;
			s.blue = transform.position;
		}
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(gameObject.name.Equals("BlueStar") && collision.gameObject.tag == "Portal") {
            GetComponent<Animator>().SetBool("isEscape", true);
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            Vector3 vec = collision.gameObject.transform.position;
            transform.position = new Vector3(vec.x, vec.y, transform.position.z);
            GameState.isGameClear = true;
            GameState.isGamePaused = true;

            if(GameState.StageLevel < 50)
                GameState.saveData.isPlayable[GameState.StageLevel] = true;
            GameState.SaveData();
        }

        if(gameObject.name.Equals("RedStar") && collision.gameObject.tag == "Wall") {

        }
    }
}