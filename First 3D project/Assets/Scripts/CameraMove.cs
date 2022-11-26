using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject Sphere;      // ссылка на шарик
    private Vector3 cam_sphere;     // вектор камера-шарик
    private float mouseY;           // mouse - Y
    private float mouseX;           // mouse - X
    private float zoom = 1;             // приближение, удаление камеры

    private const float MAX_X_ANGLE = 90;     // предельные углы поворота
    private const float MIN_X_ANGLE = 50;     // камеры вокруг оси Х
    private const float SENSITIVITY_X = 2;    // чувствительность к мыши

    private const float MAX_ZOOM = 2;         // камеры к шарику
    private const float MIN_ZOOM = 0.2f;      // камеры к шарику
    private const float SENSITIVITY_ZOOM = 10;// чувствительность к колесу мыши


    void Start()
    {
        cam_sphere = this.transform.position - Sphere.transform.position;
        mouseY = this.transform.eulerAngles.x;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseY -= SENSITIVITY_X * Input.GetAxis("Mouse Y");
            if (mouseY < MIN_X_ANGLE)
                mouseY = MIN_X_ANGLE;
            if (mouseY > MAX_X_ANGLE)
                mouseY = MAX_X_ANGLE;

            mouseX += Input.GetAxis("Mouse X");
        }

        if (Input.mouseScrollDelta != Vector2.zero)
        {
            zoom += -Input.mouseScrollDelta.y / SENSITIVITY_ZOOM;
            if (zoom < MIN_ZOOM)
                zoom = MIN_ZOOM;
            if (zoom > MAX_ZOOM)
                zoom = MAX_ZOOM;
        }
    }

    void LateUpdate()
    {
        // пересчитываем позицию камеры относительно шарика
        this.transform.position = Sphere.transform.position 
            + Quaternion.Euler(0, mouseX, 0) * cam_sphere * zoom;
        // поворачиваем камеру
        this.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
// ограничить угол поворота камеры вокруг Х в диапазоне 35..70 градусов