using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public static GameManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (Instance == null)
                {
                    GameObject obj = new GameObject();
                    Instance = obj.AddComponent<GameManager>();
                }
            }

            return Instance;
        }
    }

    private GameObject player;
    public PlayerHealth ph {get; set;}



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

        if(player == null)
        player = GameObject.Find("Player");

        ph = player.GetComponent<PlayerHealth>();
    }

    public static Transform playerTrm()
    {
        return instance.player.transform;
    }

    public static bool IsPlayerDead()
    {
        return Instance.ph.dead;
    }
}
