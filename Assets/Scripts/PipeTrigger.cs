using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public GameManager mGameManagerRef;

    private void Start()
    {
        mGameManagerRef = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (mGameManagerRef != null)
        {
            if (other.gameObject.layer == 3)
            {
                mGameManagerRef.AddScore();
            }
            
        }
    }
}
