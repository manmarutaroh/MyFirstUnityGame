using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContoroller : MonoBehaviour
{
    int count;
    public Text countText;
    public Text clearText;
    public Button retryButton;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 5)
        {
            
            SceneManager.LoadScene("ClearSceane");

        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Items")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

        if (other.tag == "Enemy")
        {
            
            SceneManager.LoadScene("GameOverSceane");
        }
    }

    private void SetCountText()
    {
        countText.text = "ゲット数:"+count.ToString();
    }

    public void RetryStage()
    {
        SceneManager.LoadScene("GameSceane");
    }
    
}
