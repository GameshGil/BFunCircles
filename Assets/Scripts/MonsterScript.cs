using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour 
{

    public GameObject spawnField;
    
    private float offset;
    private float maxX, maxY;
    private float x, y;

    void Start()
    {
        //Получение области телепорта, коллайдера области телепорта и самого телепортирующегося
        SpriteRenderer spawnFieldSprite = spawnField.GetComponent<SpriteRenderer>();
        BoxCollider2D fieldCollider = spawnField.GetComponent<BoxCollider2D>();
        SpriteRenderer enemytSprite = GetComponent<SpriteRenderer>();

        //Получение отступа
        offset = Mathf.Min(fieldCollider.size.x, fieldCollider.size.y) +
            Mathf.Max(enemytSprite.bounds.size.x, enemytSprite.bounds.size.y) / 2;
        maxX = spawnFieldSprite.bounds.size.x / 2 - offset;
        maxY = spawnFieldSprite.bounds.size.y / 2 - offset;
        //Телепорт врага
        StartCoroutine(Teleport());

    }

    //Описание функции телепорта
    public IEnumerator Teleport()
    {
        while (true) { 
            x = Random.Range(-maxX, maxX);
            y = Random.Range(-maxY, maxY);
            yield return new WaitForSeconds(3f);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    //Убийство главного персонажа при касании
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HeroScript>().isDead = true;
        }
    }
}
