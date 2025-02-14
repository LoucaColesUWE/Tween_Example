using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoManager : MonoBehaviour
{
    private bool juiceEnabled = false;

    public delegate void JuiceChanged(bool _juiceEnabled);
    public static JuiceChanged OnJuiceChanged;

    public delegate void CancelPressed();
    public static CancelPressed OnCancelPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            juiceEnabled = !juiceEnabled;
            OnJuiceChanged?.Invoke(juiceEnabled);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            OnCancelPressed?.Invoke();
        }
    }
}
