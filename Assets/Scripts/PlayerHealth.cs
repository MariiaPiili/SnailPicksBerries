using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthPrefab;
    public GameObject GameOverText;

    public Button RestartButton;

    public Transform HealthContainer;
    //public HorizontalLayoutGroup HorizontalLayoutGroup;

    public List<GameObject> HealthList = new List<GameObject>();

    public int HealthCount;

    private int MaxHealth = 3;
    void Start()
    {
        HealthCount = MaxHealth;
        for (int i = 0; i < MaxHealth; i++)
        {
            GameObject health = Instantiate(HealthPrefab, HealthContainer);
            HealthList.Add(health);
        }
        //HorizontalLayoutGroup.enabled = false; //компонент отключается через enabled = false
    }

    [ContextMenu("TakeDamage")]
    public void DebugTakeDamage()
    {
        HealthCount--;
    }

    void Update()
    {
        for (int i = 0; i < HealthList.Count; i++)
        {
            if (i < HealthCount)
            {
                HealthList[i].SetActive(true);
            }
            else
            {
                HealthList[i].SetActive(false);
            }

        }
        if (HealthCount <= 0)
        {
            Destroy(gameObject);
            GameOverText.SetActive(true);
            RestartButton.gameObject.SetActive(true);
        }

    }
}
