using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class QuestItem : MonoBehaviour
{
    public GameObject quest;
    public Text text;
    private int finish = 0;
    public Text mainQuest;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sphere" & finish == 1)
        {
            text.text = "Нажмите Q чтобы открыть.";
            Debug.Log("Finish");
        }
        if(other.tag == "Finish")
        {
            text.text = "Нажмите E чтобы подобрать. ";
        }
        if (other.tag == "Finish" & Input.GetKeyDown(KeyCode.E))
        {
            mainQuest.text = "Откройте дверь.";
            finish++;
            Destroy(quest);
            text.text = " ";
        }
        if (other.tag == "Finish" & finish == 1 )
        {
            mainQuest.text = "";
        }
        if (other.tag == "Sphere" & Input.GetKeyDown(KeyCode.Q))
        {
            mainQuest.text = "Вы прошли уровень.";
            SceneManager.LoadScene(2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        text.text = " ";
    }
}

