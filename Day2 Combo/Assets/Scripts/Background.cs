using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public GameObject Background1;
    public GameObject Background2;
    public GameObject Background3;
    public GameObject Background4;
    public float RepeatRate=0.2f;
    private int random;
    private int current=1;

    void Start () {
        InvokeRepeating("ChangeColor", 6.0f, RepeatRate);
	}

    void ChangeColor() {

        

        random = Random.Range(1, 5);
        Debug.Log(random);
        if (random == current)
        {
            if (random == 4) { current = 1; }
            else { current++; }
        }
        else { current = random; }

        switch (current)
        {
            case 1:
                Background1.SetActive(true);
                Background2.SetActive(false);
                Background3.SetActive(false);
                Background4.SetActive(false);
                break;
            case 2:
                Background1.SetActive(false);
                Background2.SetActive(false);
                Background3.SetActive(true);
                Background4.SetActive(false);
                break;
            case 3:
                Background1.SetActive(false);
                Background2.SetActive(true);
                Background3.SetActive(false);
                Background4.SetActive(false);
                break;
            case 4:
                Background1.SetActive(false);
                Background2.SetActive(false);
                Background3.SetActive(false);
                Background4.SetActive(true);
                break;
            default:
                Background1.SetActive(true);
                Background2.SetActive(false);
                Background3.SetActive(false);
                Background4.SetActive(false);
                break;
        }
        Debug.Log(random);
    }
	}
