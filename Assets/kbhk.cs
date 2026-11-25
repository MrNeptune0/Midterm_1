using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class code : MonoBehaviour
{
    [Header("Animators")]
    public Animator p1Anim;
    public Animator enemyAnim;

    [Header("Health Settings")]
    public int enemyHealth = 100;
    public int p1Health = 100;
    public TextMeshProUGUI enemyHealthText;
    public Image enemyHealthBar;
    public Image p1HealthBar;

    [Header("Effects & UI")]
    public ParticleSystem attack1Effect;
    public ParticleSystem attack2Effect;
    public GameObject gameOverPanel;

    private bool isGameOver = false;

    void Start()
    {
        UpdateUI();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void Attack1()
    {
        if (isGameOver) return;

        // Saldırı animasyonlarını oynat
        if (p1Anim != null) p1Anim.SetTrigger("Attack");
        if (enemyAnim != null) enemyAnim.SetTrigger("Hurt");

        // 1. Efekti sıfırla ve tekrar oynat
        if (attack1Effect != null)
        {
            attack1Effect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            attack1Effect.Play(true);
        }

        // Hasar ver (10 hasar)
        TakeDamage(10);
    }

    public void Attack2()
    {
        if (isGameOver) return;

        // Saldırı animasyonlarını oynat
        if (p1Anim != null) p1Anim.SetTrigger("Attack");
        if (enemyAnim != null) enemyAnim.SetTrigger("Hurt");

        // 2. Efekti sıfırla ve tekrar oynat
        if (attack2Effect != null)
        {
            attack2Effect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            attack2Effect.Play(true);
        }

        // Hasar ver (20 hasar)
        TakeDamage(20);
    }

    void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth < 0) enemyHealth = 0;

        UpdateUI();

        if (enemyHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (enemyHealthText != null)
        {
            enemyHealthText.text = enemyHealth.ToString();
        }

        if (enemyHealthBar != null)
        {
            enemyHealthBar.fillAmount = enemyHealth / 100f;
        }

        if (p1HealthBar != null)
        {
            p1HealthBar.fillAmount = p1Health / 100f;
        }
    }

    void GameOver()
    {
        isGameOver = true;

        if (enemyAnim != null)
        {
            enemyAnim.SetBool("Death", true);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}