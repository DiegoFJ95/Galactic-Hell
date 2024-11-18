using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCount : MonoBehaviour
{

    public TextMeshProUGUI enemyCountText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;


    private void UpdateText()
    {
        enemyCountText.text = $"Enemies: {GameObject.FindGameObjectsWithTag("Wing").Length}";
    }

    private void WinScreen()
    {
        if(GameObject.FindGameObjectsWithTag("Tail").Length == 0){
            winText.text = $"YOU WIN!!";
        }

    }

    private void LoseScreen()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0){
            loseText.text = $"YOU LOSE";
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        WinScreen();
        LoseScreen();
    }
}
