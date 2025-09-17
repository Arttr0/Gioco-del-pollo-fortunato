using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public static float normalspeed;
    public float JumpForce;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float CheckRadius;
    public LayerMask whatIsGround;

    public Animator anim;
    private UIGame uiGame;
    public static int HP;
    public int HP1;
    public GameObject scorlypa;

    // Переменная для хранения значения Block
    public int blockValue;

    private void Start()
    {
        Time.timeScale = 1f;
        HP = 3;
        speed = 0f;
        rb = GetComponent<Rigidbody2D>();
        uiGame = GameObject.Find("UIGame").GetComponent<UIGame>();
        rb.gravityScale = 3f;
        scorlypa.SetActive(false);
        blockValue = 0; // Устанавливаем значение 0 при выходе
        PlayerPrefs.SetInt("BlockValue", blockValue);
        blockValue = 0; // Изначально значение Block равно 0
        normalspeed = 5f;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed != 0)
        {
            anim.SetBool("isRunning", true);
        }
       /* if (scorlypa.activeSelf)
        {
            blockValue = 1; // Устанавливаем значение 1 при входе
            PlayerPrefs.SetInt("BlockValue", blockValue); // Сохраняем значение в PlayerPrefs
        }
        else {
            blockValue = 0; // Устанавливаем значение 1 при входе
            PlayerPrefs.SetInt("BlockValue", blockValue); // Сохраняем значение в PlayerPrefs
        }*/
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * JumpForce;
        }
        if (isGrounded == true)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);
        }
        HP1 = HP;
        if (HP <= 0)
        {
            uiGame.PanelLose.SetActive(true);
        }
    }

    public void Jump()
    {
        if (isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
            AudioManager.Instance.PlaySFX(2);
        }
    }

    public void Left()
    {
        if (speed >= 0)
        {
            speed = -normalspeed;
        }
        transform.eulerAngles = new Vector3(0, 180, 0);
        AudioManager.Instance.PlaySFX(1);
    }

    public void Right()
    {
        if (speed <= 0)
        {
            speed = +normalspeed;
        }
        transform.eulerAngles = new Vector3(0, 0, 0);
        AudioManager.Instance.PlaySFX(1);
    }

    public void Buttonup()
    {
        speed = 0;
        anim.SetBool("isRunning", false);
        rb.gravityScale = 3f;
        if (AudioManager.Instance.IsSFXPlaying(1))
        {
            AudioManager.Instance.StopSFX();
        }
    }

    public void Down()
    {
        rb.gravityScale = 7f;
        AudioManager.Instance.PlaySFX(0);
    }

    public void scorlypaOn()
    {
        StartCoroutine(ScorlypaCoroutine());
    }

    private IEnumerator ScorlypaCoroutine()
    {
        blockValue = 1; // Устанавливаем значение 0 при выходе
        PlayerPrefs.SetInt("BlockValue", blockValue);
        AudioManager.Instance.PlaySFX(0);
        PlayerPrefs.SetInt("PokypkaSkorlypa", 0);
        Debug.Log("1");
        scorlypa.SetActive(true);
        yield return new WaitForSeconds(5f);
        scorlypa.SetActive(false);
        blockValue = 0; // Устанавливаем значение 0 при выходе
        PlayerPrefs.SetInt("BlockValue", blockValue);
        Debug.Log("0");
    }

    public void SpeedBoost(float boostAmount, float duration)
    {
        StartCoroutine(SpeedBoostCoroutine(boostAmount, duration));
    }

    public void SpeedBoostButtonPressed()
    {
        SpeedBoost(5f, 5f); // Например, увеличиваем скорость на 5 на 5 секунд
    }

    private IEnumerator SpeedBoostCoroutine(float boostAmount, float duration)
    {
        AudioManager.Instance.PlaySFX(0);
        PlayerPrefs.SetInt("PokypkaFastSpeed", 0);
        // Увеличиваем скорость
        normalspeed += boostAmount;
        anim.speed *= 2;
        // Ждем указанное время
        yield return new WaitForSeconds(duration);
        // Возвращаем скорость обратно
        normalspeed -= boostAmount;
        anim.speed /= 2;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            uiGame.PanelFinish.SetActive(true);
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LevelsCompleted", currentLevelIndex + 1);
            if (HP == 3)
            {
                PlayerPrefs.SetInt("Achivka1", 1);
            }
            AudioManager.Instance.PlaySFX(4);
        }
        if (other.CompareTag("Slow")) // Проверяем, что объект - замедляющий
        {
            normalspeed = 3;
            Debug.Log("1");
        }
        if (other.CompareTag("Block")) // Проверяем, что объект - блок
        {
            Debug.Log("1");
            blockValue = 1; // Устанавливаем значение 1 при входе
            PlayerPrefs.SetInt("BlockValue", blockValue); // Сохраняем значение в PlayerPrefs
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slow"))
        {
            normalspeed = 5;
            Debug.Log("2");
        }
        if (other.CompareTag("Block")) // Проверяем, что объект - блок
        {
            Debug.Log("0");
            blockValue = 0; // Устанавливаем значение 0 при выходе
            PlayerPrefs.SetInt("BlockValue", blockValue); // Сохраняем значение в PlayerPrefs
        }
    }
}