using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody mRigidBody;

    public float JumpStrength = 10.0f;

    public enum  PLAYER_STATE {
        PLAYABLE,
        UNPLAYABLE
    }

    private PLAYER_STATE mState;


    // Update is called once per frame
    void Update()
    {
        if (mState == PLAYER_STATE.UNPLAYABLE)
        {
            return;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            mRigidBody.linearVelocity = Vector3.up * JumpStrength;
        }
        if (transform.position.y < 0)
        {
            Kill();
        }
      
    }
    public void Kill()
    {
        mState = PLAYER_STATE.UNPLAYABLE;
        mRigidBody.mass *= 10;
        transform.rotation = Quaternion.Euler(0, 84, 74);
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        GetComponent<Collider>().enabled = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Kill();
        }
    }
}
