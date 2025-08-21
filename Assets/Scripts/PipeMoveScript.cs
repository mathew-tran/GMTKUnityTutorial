using System;
using UnityEngine;
using UnityEngine.Events;

public class PipeMoveScript : MonoBehaviour
{
    public float MoveSpeed = 10.0f;

    public UnityEvent<GameObject> OnDeath;

    public bool bCanMove = true;

    private void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().OnGameEnd.AddListener(Stop);
    }

    private void Stop()
    {
        bCanMove = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (bCanMove == false)
        {
            return;
        }

        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;

        if (transform.position.x < -20)
        {
            OnDeath.Invoke(gameObject);

            Destroy(gameObject);
        }
    }


}
