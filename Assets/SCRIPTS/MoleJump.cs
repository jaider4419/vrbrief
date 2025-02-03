using UnityEngine;
using System.Collections;
using TMPro;

public class MoleJump : MonoBehaviour
{
    public float visibleHeight = 0.2f;
    public float hiddenHeight = -0.3f;
    public float speed = 4f;
    public float disappearDuration = 2f;
    public int score = 0;
    public TextMeshProUGUI scoreShow;
    private Vector3 targetPosition;
    private bool isVisible = false;
    private bool isMoving = false;
    public AudioSource MoleGrunt;

    private void Awake()
    {
        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z
        );

        transform.localPosition = targetPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);

        if (isMoving && Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
        {
            isMoving = false; 

            if (isVisible)
            {
                StartCoroutine(StayUpThenHide());
            }
        }
    }

    public void Rise()
    {
        if (score < 0 || isVisible) return;

        targetPosition = new Vector3(
            transform.localPosition.x,
            visibleHeight,
            transform.localPosition.z
        );

        isVisible = true;
        isMoving = true;
    }

    private IEnumerator StayUpThenHide()
    {
        yield return new WaitForSeconds(disappearDuration);
        Hide();
    }

    public void Hide()
    {
        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z
        );

        isVisible = false;
        isMoving = true;
    }

    public void OnHit()
    {
        MoleGrunt.Play();
        score++;
        scoreShow.text = "Score:" + score;
        StopAllCoroutines();
        Hide();
        StartCoroutine(RespawnAfterDelay(1.5f));
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Rise();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hammer"))
        {
            Debug.Log($"Mole hit by {other.name}!");
            OnHit();
        }
    }
}
