using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoplay = false;
    public float minX;
    public float maxX;

    private Ball ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoplay)
        {
            MoveWithMouse();
        }
        else
        {
            Autoplay();
            Vector3 paddlepos = this.transform.position;
            Vector3 ballpos = ball.transform.position;
            paddlepos.x = Mathf.Clamp(ballpos.x - 0.5f, minX, maxX);
            this.transform.position = paddlepos;
        }
	}

    void Autoplay()
    {

    }
    void MoveWithMouse()
    {
        //here we need to obtain the mouse position adn transform it to a valid screen position in x.
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }
}
