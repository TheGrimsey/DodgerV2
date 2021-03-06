﻿using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //Cached ScoreKeeper
    GameKeeper gameKeeper;

    [SerializeField]
    public GameObject popupTextPrefab;

    [Header("UI Components")]
    //Text widget that should hold score text.
    public Text ScoreText;

    //Slider for health bar.
    public Slider HealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameKeeper = GameKeeper.GetGameKeeper();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = gameKeeper.scoreKeeper.CurrentScore.ToString();

        HealthSlider.maxValue = gameKeeper.MaxPlayerHealth;
        HealthSlider.value = gameKeeper.PlayerHealth;
    }

    public void SpawnPopupText(Vector2 worldPosition, string text, Color color)
    {
        // Calculate *screen* position (note, not a canvas/recttransform position)
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);

        GameObject popupText = Instantiate(popupTextPrefab);

        popupText.transform.SetParent(transform);
        popupText.transform.position = screenPoint;

        popupText.GetComponent<PopupText>().SetText(text, color);
    }
}
