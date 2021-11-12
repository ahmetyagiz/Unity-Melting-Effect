using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool playState;

    [SerializeField] private Joystick joystick;
    [SerializeField] private float sideForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minX, maxX;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject winPanel, losePanel;

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
            DOTween.KillAll();
            playState = false;
            Invoke(nameof(Restart), 3);
            losePanel.SetActive(true);
            losePanel.transform.DOScale(1, 1);

            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CandleCollect"))
        {
            Destroy(other.gameObject);
            DOTween.KillAll();
            transform.DOScaleY(1, 0.25f).OnComplete(() =>
            {
                transform.DOScaleY(0, 8);
            });
        }

        if (other.gameObject.CompareTag("Finish")) //Oyun Bitti
        {
            DOTween.KillAll();

            playState = false;

            Invoke(nameof(Restart), 3);

            winPanel.SetActive(true);
            winPanel.transform.DOScale(1, 1);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            DOTween.KillAll();
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.25f, transform.localScale.z);
            transform.DOScaleY(0, 8);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}