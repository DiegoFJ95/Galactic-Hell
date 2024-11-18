using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCounter : MonoBehaviour
{

    public TextMeshProUGUI bulletCountText;


    private void UpdateText()
    {
        bulletCountText.text = $"Enemy bullets: {GameObject.FindGameObjectsWithTag("EvilBullet").Length}";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
}
