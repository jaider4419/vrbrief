using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleJump : MonoBehaviour
{

    [Header("Popup Settings")]

    [SerializeField] float popHeight = 1;
    Vector3 startPos;
    Vector3 popPos;

    [Header("Popup Settings")]

    [SerializeField] int popState = 0;
    [SerializeField] float waitTime = 1;

    private 



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        popPos = transform.position;
        popPos.y += popHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (popState == 1)
        {
            transform.position = Vector3.Lerp(transform.position, popPos, 5 * Time.deltaTime);
            if (Mathf.Abs(transform.position.y - popPos.y) < 0.1f)
            {
                popState = 2;
                waitTime = Random.Range(0.5f, 2);
            }
        }

        if (popState == 2)
        {
            waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                popState = 3;
            }
        }

        if (popState == 3)
// where the mole will go?
        {
            transform.position = Vector3.Lerp(transform.position, startPos, 5 * Time.deltaTime);

            if (Mathf.Abs(transform.position.y - startPos.y) < 0.1f)
            {
                popState = 0;
                transform.position = startPos;
            }
        }
    }

    public void pop()
    {
        if (popState == 0)
        {
            popPos.y += popHeight;
            popState = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "hammer" && popState > 0)
        {
            popState = 0;
            transform.position = startPos;
            GameController.score += 10;

        }

    }

    
}
