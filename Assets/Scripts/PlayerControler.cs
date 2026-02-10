using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //score variable
    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;
    
    //physica variable
    public float thrustForce = 1f;

    Rigidbody2D rb;

    //ui variable
    public UIDocument uiDocument;
    private Label scoreText;
    private Button restartButton;
    private Button pauseButton;
    private Button resumeButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
        pauseButton = uiDocument.rootVisualElement.Q<Button>("PauseButton");
        pauseButton.clicked += Pause;
        resumeButton = uiDocument.rootVisualElement.Q<Button>("ResumeButton");
        resumeButton.clicked += Resume;
        resumeButton.style.display = DisplayStyle.None;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;

        if (Mouse.current.leftButton.isPressed)
        {

            // Calculate mouse direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;

            // Move player in direction of mouse
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        restartButton.style.display = DisplayStyle.Flex;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        resumeButton.style.display = DisplayStyle.Flex;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        resumeButton.style.display = DisplayStyle.None;
    }


}