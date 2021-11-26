using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool playState;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float sideForce, moveSpeed;
    [SerializeField] private float minX, maxX;
    [SerializeField] private GameObject Camera;

    //Unity Event Kullanýmý
    [Serializable] public class CanvasEvent : UnityEvent { }

    public CanvasEvent winState;
    public CanvasEvent loseState;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playState = true;
        transform.DOScaleY(0, 8);
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        if (playState == true)
        {
            rb.velocity = new Vector3(joystick.Horizontal * sideForce, rb.velocity.y, moveSpeed);
        }

        if (transform.localScale.y < 0.1f)
        {
            DOTween.Kill(transform);
            playState = false;
            loseState.Invoke(); //Unity Event kullanýmý
            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CandleCollect"))
        {
            Destroy(other.gameObject);
            DOTween.Kill(transform);
            transform.DOScaleY(1, 0.25f).OnComplete(() =>
            {
                transform.DOScaleY(0, 8);
            });
        }

        if (other.gameObject.CompareTag("Finish")) //Oyun Bitti
        {
            DOTween.Kill(transform);
            playState = false;
            winState.Invoke(); //Unity Event kullanýmý
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            DOTween.Kill(transform);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.25f, transform.localScale.z);
            transform.DOScaleY(0, 8);
        }

        if (other.gameObject.CompareTag("Booster"))
        {
            StartCoroutine(nameof(SpeedBoostRoutine));
        }
    }

    IEnumerator SpeedBoostRoutine()
    {
        moveSpeed += 3;
        yield return new WaitForSeconds(1);
        moveSpeed -= 3;
    }
}