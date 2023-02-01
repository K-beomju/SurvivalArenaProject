using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private GameObject player;
    public PlayerHealth ph {get; set;}
    public Transform hpTrm;
    [SerializeField] private GameOverPanel gameOverPanel;

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
}
