using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Ease titleEase;
    [SerializeField] private RectTransform titleText;
    [SerializeField] private RectTransform titleButtonGroup;

    [SerializeField] private Button startButton;
    [SerializeField] private Button adsButton;

    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject titleCanvas;

    private EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        startButton.onClick.AddListener(() => GameStart());    
    }

    private void Start() 
    {
        Sequence sq = DOTween.Sequence();
        sq.Append(titleText.DOAnchorPosY(300,3).SetEase(titleEase));
        sq.Join(titleButtonGroup.DOAnchorPosY(0,3).SetEase(titleEase));

    }


    public void GameStart()
    {
        Sequence sq = DOTween.Sequence();
        sq.Append(titleText.DOAnchorPosY(1300,3).SetEase(titleEase));
        sq.Join(titleButtonGroup.DOAnchorPosY(-1000,3).SetEase(titleEase));
        sq.InsertCallback(2,() => {
            gameCanvas.SetActive(true);
            titleCanvas.SetActive(false);
            enemySpawner.isStart = true;
        });
        
    }
}
