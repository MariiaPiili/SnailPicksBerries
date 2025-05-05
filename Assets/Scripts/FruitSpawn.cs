using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    public List<GameObject> Fruits = new List<GameObject>();

    public GameObject Player;

    private float _speedChangeTime = 2f;

    void Start()
    {
        StartCoroutine("SpawnFruit");
    }

    public IEnumerator SpawnFruit()
    {

        while (Player != null)
        {
            GameObject fruit = Fruits[Random.Range(0, Fruits.Count)];
            float x = Random.Range(-11, 11);
            yield return new WaitForSeconds(_speedChangeTime);
            GameObject spawnFruit = Instantiate(fruit, new Vector3(x, 6f, 5.5f), Quaternion.identity);
            spawnFruit.transform.SetParent(transform); //родитель этого заспавненного объекта - это родитель, на котором лежит скрипт
            if (spawnFruit.GetComponent<Berry>())
            {
                spawnFruit.GetComponent<Berry>().PlayerHealth = PlayerHealth; //так как ягодка префаб,мы не можем на нее назначить PlayerHealth напрямую, и каждый раз когда спавним, назначаем через спавн
            }

            yield return null;
        }
        Destroy(gameObject); //когда цикл закончится, т е когда умрет игрок, родит обьект уничтожится и дочерние обьекты тоже уничтожатся. т е когда появится надпись gamr over, ягодки больше не будут сыпаться
    }

    public void Update()
    {
        /*
        if(Time.time > 60)
            _speedChangeTime = 1.5f;
        if (Time.time > 120)
            _speedChangeTime = 1f;
        */

        _speedChangeTime = 2 - 0.25f * (Time.time / 60); //когда прошло 60 сек, 60/60=1, 2-0.25*1=1.15

    }
}
