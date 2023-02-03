using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public PlayerHealth ph {get; set;}
    public Transform hpTrm;

    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private LevelSlider levelSlider;

    private GameObject player;

    private void Awake()
    {
        if(player == null)
        player = GameObject.Find("Player");

        ph = player.GetComponent<PlayerHealth>();

        ph.OnDeath += () => { gameOverPanel.gameObject.SetActive(true); };
    }

    public static Transform playerTrm()
    {
        return Instance.player.transform;
    }

    public static bool IsPlayerDead()
    {
        return Instance.ph.dead;
    }

    public void AddGuage(float exp)
    {
        levelSlider.AddGuage(exp);
    }
}
