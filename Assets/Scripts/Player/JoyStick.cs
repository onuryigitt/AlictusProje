using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{

    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickButton;
    [SerializeField] private float moveFactor;
    private Vector3 move;

    private bool canControlJoystick;
    private Vector3 tapPosition;
    void Start()
    {
        HideJoyStick();
    }
    public void TappedOnJoystickZone ()    //bu dokunduðunu algýlama kodu 
    {
        //Debug.Log("Ekrana Dokunuldu");     consol için
        ShowJoyStick();
        tapPosition = Input.mousePosition;
        joystickOutline.position = tapPosition;
    }

    private void ShowJoyStick()    //dokunduðunda joysticki göster
    {
        joystickOutline.gameObject.SetActive(true);
        canControlJoystick = true;
    }
    private void HideJoyStick()    // parmaðýný çektiðinde Joysticki gösterme
    {
        joystickOutline.gameObject.SetActive(false);
        canControlJoystick = false;
        move = Vector3.zero;



    }

    public void ControlJoystick()   //Joystick ile karakter kontrolü
    {

        Vector3 currenPosition = Input.mousePosition;
        Vector3 direction = currenPosition - tapPosition;

        float canvasYScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y;
        float moveMagnitude = direction.magnitude * moveFactor * canvasYScale;

        float joystickOutlineHalfWidth = joystickOutline.rect.width / 2;
        float newWidht = joystickOutlineHalfWidth * canvasYScale;

        moveMagnitude = Mathf.Min(moveMagnitude, newWidht);

        move = direction.normalized * moveMagnitude;
        Vector3 targetPos =tapPosition + move;

        joystickButton.position = targetPos;

        if (Input.GetMouseButtonUp(0))
        {
            HideJoyStick();
        }
    }


    public Vector3 GetMovePosition ()
    {
        return move / 1.75f;
    }


    // Update is called once per frame
    void Update()
    {
        if (canControlJoystick)
        {
             ControlJoystick();
        }
     
    }
}
