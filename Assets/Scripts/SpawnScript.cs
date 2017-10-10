using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour 
{
    public GameObject spawnField;
    public GameObject spawnObject;

    public int count;

    private float offset;
    private float maxX, maxY;
    private float x, y;

    void Start () 
	{
        //Получение области спавна, коллайдера области спавна и объекта спавна
        SpriteRenderer spawnFieldSprite = spawnField.GetComponent<SpriteRenderer>();
        BoxCollider2D fieldCollider = spawnField.GetComponent<BoxCollider2D>();
        SpriteRenderer spawnObjectSprite = spawnObject.GetComponent<SpriteRenderer>();
        
        //Получение отступа
        offset = Mathf.Min(fieldCollider.size.x, fieldCollider.size.y) +
            Mathf.Max(spawnObjectSprite.bounds.size.x, spawnObjectSprite.bounds.size.y) / 2;
        maxX = spawnFieldSprite.bounds.size.x / 2 - offset;
        maxY = spawnFieldSprite.bounds.size.y / 2 - offset;
        //Спавн объектов
        Spawn(count);
    }

    //Описание функции спавна
    public void Spawn(int count)
    {
        for (var i = 0; i < count; i++)
        {
            x = Random.Range(-maxX, maxX);
            y = Random.Range(-maxY, maxY);
            Instantiate(spawnObject, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
