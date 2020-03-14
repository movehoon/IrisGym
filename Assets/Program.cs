using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    public Camera cam;
    public GameObject gameObject;
    public Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.Log("MousePos: " + Input.mousePosition);
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/4, Screen.height/2));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            // Do something with the object that was hit by the raycast.
            Debug.Log("ray:" + ray.ToString() + ", hit: " + hit.point);
        }
        //gameObject.transform.localPosition = hit.point;
        gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, hit.point, Time.deltaTime);

        //메인카메라가 바라보는 방향입니다.
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        Debug.Log("dir: " + dir.ToString());
        //카메라가 바라보는 방향으로 팩맨도 바라보게 합니다.
        transform.localRotation = cam.transform.localRotation;
        //팩맨의 Rotation.x값을 freeze해놓았지만 움직여서 따로 Rotation값을 0으로 세팅해주었습니다.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        //바라보는 시점 방향으로 이동합니다.
        gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);
    }
}
