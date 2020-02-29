using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healtValue = 100;
    Text textComponenet;
    // Start is called before the first frame update
    void Start()
    {
        textComponenet = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponenet.text = healtValue.ToString();
    }
}
