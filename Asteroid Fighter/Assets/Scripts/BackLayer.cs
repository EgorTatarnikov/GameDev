using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLayer : MonoBehaviour
{
    #region Fields
    GameObject gameManager;
    float force = 0.3f;
    Rigidbody2D rb;
    bool instantiated = false;
    #endregion

    #region Methods
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);

        //order in sorting layer
        GetComponent<SpriteRenderer>().sortingOrder = gameManager.GetComponent<GameManagerScript>().BackLayerSortingOrger;
        gameManager.GetComponent<GameManagerScript>().ChangeBackLayerSortingOrger();
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            if (!instantiated)
            {
                Object.Instantiate(Resources.Load("BackLayer"));
                instantiated = true;
            }
        }

        if (transform.position.y < (-12))
        {
            Destroy(gameObject);
        }
    }
    #endregion
}