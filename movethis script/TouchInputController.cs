using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// タッチ入力制御.
/// </summary>
[DefaultExecutionOrder(-1)] // Updateを優先的に呼び出す為.
public sealed class TouchInputController : MonoBehaviour
{
	/// <summary>インスタンス</summary>
	static private TouchInputController instance;
	/// <summary>インスタンスアクセッサ</summary>
	static public TouchInputController Instance
	{
		get
		{
			if (instance != null) { return instance; }
			var gameObject = new GameObject();
			instance = gameObject.AddComponent<TouchInputController>();
			gameObject.name = instance.GetType().Name;
			return instance;
		}
	}


	/// <summary>uGUIと重なっているかどうか</summary>
	static public bool IsPointerOverGameObject { get; private set; }
	/// <summary>タップ操作中かどうか</summary>
	static public bool Tap { get; private set; }
	/// <summary>ドラッグ(スワイプ、フリック)操作中かどうか</summary>
	static public bool Drag { get; private set; }
	/// <summary>タップ座標</summary>
	static public Vector3 TapPosition { get; private set; }
	/// <summary>ドラッグ座標</summary>
	static public Vector3 DragPosition { get; private set; }
	/// <summary>1番目のタッチ情報</summary>
	private Touch firstTouch;


	/// <summary>
	/// Unity Event Awake.
	/// </summary>
	private void Awake()
	{
		if (null == instance)
		{
			instance = this;
		}
		else if (this != instance)
		{
			DestroyImmediate(gameObject);
		}
	}

	/// <summary>
	/// Unity Event Update.
	/// </summary>
	private void Update()
	{
		UpdatePointerOver();
		UpdateTouch();
	}

	/// <summary>
	/// uGUIとの重なり情報更新
	/// </summary>
	private void UpdatePointerOver()
	{
		// uGUIとの重なりを確認
		if (0 < GetTouchCount())
		{
#if UNITY_EDITOR || UNITY_STANDALONE
			IsPointerOverGameObject =
				null != EventSystem.current &&
				EventSystem.current.IsPointerOverGameObject();
#else
			IsPointerOverGameObject =
				null != EventSystem.current &&
				EventSystem.current.IsPointerOverGameObject(GetTouch(0).fingerId);
#endif
		}
		else
		{
			IsPointerOverGameObject = false;
		}
	}

	/// <summary>
	/// タッチ情報の更新
	/// </summary>
	private void UpdateTouch()
	{
		Tap = false;
		Drag = false;

		var currentTouchCount = GetTouchCount();
		if (currentTouchCount <= 0)
		{
			// タッチが検出されなかったのでfirstTouchを初期化する.
			firstTouch.fingerId = -1;
			firstTouch.position = Vector3.zero;
		}
		else
		{
			// タッチが検出されたのでfirstTouchに入力.
			var currentTouch = GetTouch(0);

			if (firstTouch.fingerId == -1)
			{
				Tap = true;
				firstTouch = currentTouch;
			}
			else
			{
				// ドラッグは同じFingerIDを追い続ける.
				if (firstTouch.fingerId == currentTouch.fingerId)
				{
					Drag = true;
					firstTouch = currentTouch;
				}
			}
		}

		if (Tap)
		{
			TapPosition = firstTouch.position;
		}

		if (Drag)
		{
			DragPosition = firstTouch.position;
		}
	}

	/// <summary>
	/// 入力数の取得.
	/// </summary>
	/// <returns></returns>
	private int GetTouchCount()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		return Input.GetMouseButton(0) ? 1 : 0;
#elif UNITY_ANDROID || UNITY_IOS
		return Input.touchCount;
#else
		return 0;
#endif
	}

	/// <summary>
	/// 入力情報の取得.
	/// </summary>
	/// <param name="touchIndex">タッチ番号</param>
	/// <returns>入力座標</returns>
	private Touch GetTouch(int touchIndex)
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		return new Touch() {
			fingerId = 0,
			position = Input.mousePosition,
		};
#elif UNITY_ANDROID || UNITY_IOS
		return Input.GetTouch(touchIndex);
#else
		return new Touch()
		{
			fingerId = -1,
		};
#endif
	}

}