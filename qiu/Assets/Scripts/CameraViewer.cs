using UnityEngine;
using System.Collections;

public class CameraViewer : MonoBehaviour
{
	public static CameraViewer Instance;

	public Transform target;                // 注视的目标点
	public Vector3 targetOffset;            // 目标点的偏移量

	public float distance = 5.0f;           // 距离值
	public float maxDistance = 20;          // 最大距离
	public float minDistance = 0.6f;        // 最小距离

	public float xSpeed = 200.0f;           // 旋转速度
	public float ySpeed = 200.0f;           // 旋转速度

	public int yMinAngleLimit = -80;        
	public int yMaxAngleLimit = 80;         
	public int xMinAngleLimit = -80;        
	public int xMaxAngleLimit = 80;         
	public int zoomRate = 40;               // 缩放比率
	public float zoomDampening = 5.0f;      // 缩放阻尼


	public float xDeg = 0.0f;
	public float yDeg = 0.0f;
	public float currentDistance;
	[HideInInspector]
	public float desiredDistance;
	public Quaternion rotation;
	private Vector3 position;
	public bool StartRotate = false;
	public static  bool ModelCameraLocked = false;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;

    //摄像机动画变量
    public bool isAutoChangeView;

	void Awake() { Init(); }


	[HideInInspector]
	public Vector3 startPos,startAngle;

	IEnumerator Start()
	{
		yield return new WaitForSeconds (0.1f);
		startPos = transform.position;
		startAngle = transform.eulerAngles;
	}

	void Init()
	{
		if(Instance == null)Instance = GetComponent<CameraViewer>();  

		if (!target)
        {
			GameObject go = new GameObject("Cam Target");
			go.transform.position = transform.position + (transform.forward * distance);
			target = go.transform;
		}

		distance = Vector3.Distance(transform.position, target.position);
		currentDistance = distance;
		desiredDistance = distance;

		position = transform.position;
		rotation = transform.rotation;

		xDeg = Vector3.Angle (Vector3.right, transform.right);
		yDeg = Vector3.Angle (Vector3.up, transform.up);
	}

	void LateUpdate()
	{
        

        
		// 鼠标滚轮 ———— 缩放远近
        
			desiredDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (desiredDistance);

		// 鼠标左键 ———— 旋转
		if (Input.GetMouseButtonDown (0))
        {
			StartRotate = false;
		}

        if (Input.GetMouseButton (0))
        {
			xDeg += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
			yDeg -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
			yDeg = ClampAngle (yDeg, yMinAngleLimit, yMaxAngleLimit);
			xDeg = ClampAngle (xDeg, xMinAngleLimit, xMaxAngleLimit);

			StartRotate = true;
		}

		if (StartRotate)
		{
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;
			rotation = Quaternion.Lerp (currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
			transform.rotation = rotation;
		}

		desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);

		position = target.position - (rotation * Vector3.forward * currentDistance + targetOffset);
		transform.position = position;
	}

	// 角度限定
	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)  angle += 360;
		if (angle > 360) angle -= 360;
		return Mathf.Clamp(angle, min, max);
    }

//    #region 摄像机动画方法 (插值自己在运行状态下鼠标移动到需要的位置，在脚本Editor模式下查看xDeg,yDeg和CurrentDistance的数值,最后个参数(true)为可继续操作摄像机视角)
//
//    /// <summary>
//    /// 相机移动完成后的控制状态
//    /// </summary>
//    public enum MoveOverControllState { Free, Lock }
//
//    /// <summary>
//    /// 仅修改视角的方法
//    /// </summary>
//    /// <param name="_xDeg">目标视角时xDeg（X轴幅度）的值.</param>
//    /// <param name="_yDeg">目标视角时yDeg（Y轴幅度）的值.</param>
//    /// <param name="_distance">目标视角时的Distance（距离）值.</param>
//    /// <param name="_changeTime">动画时长.</param>
//    /// <param name="_callback">动画完成后的回调事件.</param>
//    public void ChangeCameraView(float _xDeg,float _yDeg, float _distance, float _changeTime, System.Action _callback = null)
//    {
//        ChangeCameraView(_xDeg,_yDeg,_distance,_changeTime,MoveOverControllState.Free,_callback);
//    }
//
//    /// <summary>
//    /// 仅修改视角的方法.
//    /// </summary>
//    /// <param name="_xDeg">目标视角时xDeg（X轴幅度）的值.</param>
//    /// <param name="_yDeg">目标视角时yDeg（Y轴幅度）的值.</param>
//    /// <param name="_distance">目标视角时的Distance（距离）值.</param>
//    /// <param name="_changeTime">动画时长.</param>
//    /// <param name="_state">动画完成后相机的控制状态（Free：自由旋转，Lock：锁定不可操作）.</param>
//    /// <param name="_callback">动画完成后的回调事件.</param>
//    public void ChangeCameraView(float _xDeg, float _yDeg, float _distance, float _changeTime, MoveOverControllState _state, System.Action _callback = null)
//    {
//        isAutoChangeView = true;
//        DOTween.To(() => xDeg, x => xDeg = x, _xDeg, _changeTime);
//        DOTween.To(() => yDeg, x => yDeg = x, _yDeg, _changeTime);
//        DOTween.To(() => desiredDistance, x => desiredDistance = x, _distance, _changeTime).OnComplete(delegate {
//            if (_state == MoveOverControllState.Free)
//                isAutoChangeView = false;
//            if (_callback != null)
//                _callback();
//        });
//    }
//
//    /// <summary>
//    /// 修改目标点及视角的方法
//    /// </summary>
//    /// <param name="_targetPos">目标点（_target）的相对位置坐标.</param>
//    /// <param name="_xDeg">目标视角时xDeg（X轴幅度）的值.</param>
//    /// <param name="_yDeg">目标视角时yDeg（Y轴幅度）的值.</param>
//    /// <param name="_distance">目标视角时的Distance（距离）值.</param>
//    /// <param name="_changeTime">动画时长.</param>
//    /// <param name="_callback">动画完成后的回调事件.</param>
//    public void ChangeCameraView(Vector3 _targetPos,float _xDeg,float _yDeg,float _distance,float _changeTime,System.Action _callback = null)
//    {
//        ChangeCameraView(_targetPos,_xDeg,_yDeg,_distance,_changeTime,MoveOverControllState.Free,_callback);
//    }
//		
//
//    /// <summary>
//    /// 修改目标点及视角的方法.
//    /// </summary>
//    /// <param name="_targetPos">目标点（_target）的相对位置坐标.</param>
//    /// <param name="_xDeg">目标视角时xDeg（X轴幅度）的值.</param>
//    /// <param name="_yDeg">目标视角时yDeg（Y轴幅度）的值.</param>
//    /// <param name="_distance">目标视角时的Distance（距离）值.</param>
//    /// <param name="_changeTime">动画时长.</param>
//    /// <param name="_state">动画完成后相机的控制状态（Free：自由旋转，Lock：锁定不可操作）.</param>
//    /// <param name="_callback">动画完成后的回调事件.</param>
//    public void ChangeCameraView(Vector3 _targetPos, float _xDeg, float _yDeg, float _distance, float _changeTime, MoveOverControllState _state, System.Action _callback = null)
//    {
//        isAutoChangeView = true;
//        target.DOMove(_targetPos, _changeTime);
//        DOTween.To(() => xDeg, x => xDeg = x, _xDeg, _changeTime);
//        DOTween.To(() => yDeg, x => yDeg = x, _yDeg, _changeTime);
//        DOTween.To(() => desiredDistance, x => desiredDistance = x, _distance, _changeTime).OnComplete(delegate
//        {
//            if(_state == MoveOverControllState.Free)
//                isAutoChangeView = false;
//            
//            if (_callback != null)
//                _callback();
//        });
//    }
//    #endregion
}
