using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float control_speed;
    private int count;
    public Text countText;
    public Text winText;
    public Text lvlcompleteText;

    void Start()
    {
        
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
        lvlcompleteText.text = "";
    }

    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");


        transform.Translate (new Vector3(moveHorizontal * control_speed, 0.0f, speed) * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
            {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count: " + count.ToString();
            if (count == 5)
            {
                winText.text = "You got all!";
            }
        };

        if (other.gameObject.CompareTag("Finish"))
        {

            lvlcompleteText.text = "Level complete";
            
        };
    }
}