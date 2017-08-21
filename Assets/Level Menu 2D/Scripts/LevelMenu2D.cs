using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// LevelMenu2D is a singleton class for the Level Menus. 
/// Use <c>LevelMenu2D.I</c> to get the instance of class for the method calls.
/// </summary>
public class LevelMenu2D : Singleton<LevelMenu2D> {

	/// <summary>
	/// Gets or Sets the only instance of LevelMenu2D.
	/// Use <c>LevelMenu2D.I</c> to call the methods in this class.
	/// </summary>
	public static LevelMenu2D I {
		get {
			return (LevelMenu2D) mInstance;
		} set {
			mInstance = value;
		}
	}

	/// <summary>
	/// The Orientation Enum for the LevelMenu2D. It can be Horizontal, Vertical, or Custom.
	/// </summary>
	public enum MenuOrientation {
		Horizontal,
		Vertical,
		Custom
	}
	
	/// <summary>
	/// Current Displayed Item Index
	/// </summary>
	private int _currentItemIndex = 0;

	/// <summary>
	/// True means LevelMenu2D is moving/animating, false means it is stopped. 
	/// While animating/moving, LevelMenu2D cannot be further navigated or interacted.
	/// </summary>
	private bool _isMoving = false;

	/// <summary>
	/// Whether LevelMenu2D be Auto Updated at Runtime or not.
	/// This is ONLY for testing purpose, and you should keep it to false when publishing your game. This can slow the performance. 
	/// </summary>
	public bool autoUpdateAtRuntime = false;

	/// <summary>
	/// Whether LevelMenu2D be Auto Updated at Runtime or not.
	/// This is ONLY for testing purpose, and you should keep it to false when publishing your game. This can slow the performance. 
	/// </summary>
	public MenuOrientation orientation = MenuOrientation.Custom;

	/// <summary>
	/// The List of Items in the LevelMenu. This is list of GameObjects.
	/// You can put nested objects, 2D, or 3D objects without any problems.
	/// </summary>
	public List<GameObject> itemsList = new List<GameObject>();

	/// <summary>
	/// Initial Item Index to be load at start of LevelMenu2D.
	/// </summary>
	public int initialItemNumber = 0;

	/// <summary>
	/// The First Item of the LevelMenu2D.
	/// This is set from items list automatically.
	/// </summary>
	public GameObject firstItem;
	
	/// <summary>
	/// Whether Next/Back buttons to be shown in menu or not.
	/// </summary>
	public bool showNextBackButtons = true;

	/// <summary>
	/// Next Button Game Object
	/// </summary>
	public GameObject nextButtonObject;

	/// <summary>
	/// Back Button Game Object
	/// </summary>
	public GameObject backButtonObject;

	/// <summary>
	/// Should Increase the Order
	/// </summary>
	bool shouldIncreaseOrder = true;

	/// <summary>
	/// Whether to put items automatically based on Orientatation.
	/// This would be true in case of Horizontal or Vertical Orientation.
	/// </summary>
	public bool autoOffset = true;

	/// <summary>
	/// If itemOffset of the LevelMenu2D in case of autoOffset is false.
	/// </summary>
	public Vector2 itemOffset = new Vector3(0f, 0f);

	/// <summary>
	/// Space between items for Horizontal or Vertical Orientations. 
	/// </summary>
	public float spacingBetweenItems = 0f;

	/// <summary>
	/// EaseType of the animation to navigate items.
	/// </summary>
	public iTween.EaseType easeType;
	
	/// <summary>
	/// Animation Time for Navigation.
	/// </summary>
	public float animationTime = 0f;

	/// <summary>
	/// False means only one item is current at a time and true otherwise.
	/// </summary>
	public bool isBounded = false;

	/// <summary>
	/// Minimum Bound Index from the item list.
	/// </summary>
	public int minimumBoundIndex = 0;

	/// <summary>
	/// Maximum Bound Index from the item list.
	/// </summary>
	public int maximumBoundIndex = 0;

	/// <summary>
	/// The delegate when item is clicked.
	/// </summary>
	public delegate void OnItemClickedDelegate(int itemIndex, GameObject itemObject);

	/// <summary>
	/// The Click Event to listen for item clicks.
	/// </summary>
	public event OnItemClickedDelegate OnItemClicked;

	/// <summary>
	/// Current Item's Index
	/// </summary>
	public int CurrentItem {
		get {
			return _currentItemIndex;
		}
	}

	/// <summary>
	/// Returns whether LevelMenu2D is moving or stopped.
	/// </summary>
	public bool isMoving {
		get {
			return _isMoving;
		}
	}
	
	// Use this for initialization
	void Start () {
		firstItem = itemsList[0];
		createMenu();
		gotoItem(initialItemNumber);
	}

	// Update is called once per frame
	void Update () {
		if (autoUpdateAtRuntime)
			createMenu();
	}

	/// <summary>
	/// Recreates the LevelMenu2D from scratch.
	/// </summary>
	public void recreateMenu()
	{
		initialItemNumber = CurrentItem;
		firstItem = itemsList[CurrentItem];
		_currentItemIndex = 0;
		createMenu();
		gotoItem(initialItemNumber);
	}
	
	/// <summary>
	/// Creates the LevelMenu2D from scratch.
	/// </summary>
	public void createMenu ()
	{


		// If autoOffset is true, then set itemOffset to zero.
		if (autoOffset)
			itemOffset = Vector3.zero;
		// If autoSet is false, then set orientation to Custom.
		else
			orientation = MenuOrientation.Custom;

		// If showNextBeckButtons is false, then use items as buttons
		//if (showNextBackButtons == false)
		{
			for (int i=0; i<itemsList.Count; i++)
			{
				if (nextButtonObject != null) nextButtonObject.SetActive(false);
				if (backButtonObject != null) backButtonObject.SetActive(false);
				itemsList[i].AddComponent<ClickTouchScript>();
				itemsList[i].AddComponent<BoxCollider>();
			}
		}
		// If showNextBackButtons is true, then place the hidden buttons for carousel
		if (showNextBackButtons == true)
		{
			if (nextButtonObject != null && backButtonObject != null)
			{
				nextButtonObject.SetActive(true);
				backButtonObject.SetActive(true);
				nextButtonObject.AddComponent<ClickTouchScript>();
				backButtonObject.AddComponent<ClickTouchScript>();
				nextButtonObject.AddComponent<BoxCollider>();
				backButtonObject.AddComponent<BoxCollider>();
				nextButtonObject.GetComponent<Renderer>().sortingOrder = itemsList.Count;
				backButtonObject.GetComponent<Renderer>().sortingOrder = itemsList.Count;
			}
		}

		if (itemsList.Count > 0)
		{
			Camera cam = (Camera) GameObject.FindObjectOfType<Camera> ();
			Vector3 camPos = cam.transform.position;
			camPos.z = 0f;
			camPos.y = 0f;
			//itemsList[0].transform.position = camPos;
			//itemsList[0].transform.position = this.transform.position;
			itemsList[0].transform.position = firstItem.transform.position;

			for (int i=1; i<itemsList.Count; i++)
			{
				Vector3 changePos = itemsList[i-1].transform.position;
				if (autoOffset)
				{
					if (orientation == MenuOrientation.Custom || orientation == MenuOrientation.Horizontal)
						itemOffset.x = itemsList[i-1].GetComponent<Renderer>().bounds.size.x + spacingBetweenItems;
					else if (orientation == MenuOrientation.Vertical)
						itemOffset.y = itemsList[i-1].GetComponent<Renderer>().bounds.size.y + spacingBetweenItems;
				}
				changePos.x += itemOffset.x;
				changePos.y += itemOffset.y;
				itemsList[i].transform.position = changePos;
				if (shouldIncreaseOrder)
					itemsList[i].GetComponent<Renderer>().sortingOrder = itemsList[i-1].GetComponent<Renderer>().sortingOrder + 1;
				else 
					itemsList[i].GetComponent<Renderer>().sortingOrder = itemsList[i-1].GetComponent<Renderer>().sortingOrder - 1;
			}
		}
	}

	/// <summary>
	/// Navigates to the item object passed in parameter.
	/// </summary>
	/// <param name="itemObject">A GameObject of any item from the item list.</param>
	public void gotoItem(GameObject itemObject)
	{
		if (indexOf(itemObject) < 0)
			return;

		gotoItem(indexOf(itemObject));
	}

	/// <summary>
	/// Navigates to the item index passed in parameter.
	/// </summary>
	/// <param name="itemNum">Index of of any item from the item list.</param>
	public void gotoItem(int itemNum)
	{
		if (itemNum < 0 || itemNum >= itemsList.Count || itemsList.Count <= 0 || CurrentItem >= itemsList.Count || CurrentItem < 0)
			return;
		if (isBounded)
		{
			if (itemNum > maximumBoundIndex)
			{
				itemNum = maximumBoundIndex;
			} else if (itemNum < minimumBoundIndex)
			{
				itemNum = minimumBoundIndex;
			}
		}

		int differnece = 0;
		// Moving Forward
		if (itemNum > CurrentItem)
		{
			differnece = (itemNum - CurrentItem);
			for (int i=0; i<itemsList.Count; i++)
			{
				_isMoving = true;
				if (orientation == MenuOrientation.Horizontal)
				{
					iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x",itemsList[i].transform.position.x - (itemOffset.x*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
				}
				else if (orientation == MenuOrientation.Vertical)
					iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"y",itemsList[i].transform.position.y - (itemOffset.y*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
				else if (orientation == MenuOrientation.Custom)
					iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x", itemsList[i].transform.position.x - (itemOffset.x*differnece), "y",itemsList[i].transform.position.y -(itemOffset.y*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));//iTween.MoveTo(itemsList[i], iTween.Hash("x", itemsList[i].transform.position.x + (itemOffset.x*differnece), "y",itemsList[i].transform.position.y +(itemOffset.y*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));

			}
			_currentItemIndex = itemNum;
		}
		// Moving Backwards
		if (itemNum < CurrentItem)
		{
			differnece = (CurrentItem - itemNum);
			for (int i=0; i<itemsList.Count; i++)
			{
				_isMoving = true;
				if (orientation == MenuOrientation.Horizontal)
				{
					iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x",itemsList[i].transform.position.x + (itemOffset.x*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
				}
				else if (orientation == MenuOrientation.Vertical)
					iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"y",itemsList[i].transform.position.y + (itemOffset.y*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
				else if (orientation == MenuOrientation.Custom)
					iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x", itemsList[i].transform.position.x + (itemOffset.x*differnece), "y",itemsList[i].transform.position.y +(itemOffset.y*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));//iTween.MoveTo(itemsList[i], iTween.Hash("x", itemsList[i].transform.position.x + (itemOffset.x*differnece), "y",itemsList[i].transform.position.y +(itemOffset.y*differnece), "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));

			}
			_currentItemIndex = itemNum;
		}
		sortOrderOfItems();

	}

	/// <summary>
	/// Returns index of the GameObject of item passed in parameter
	/// </summary>
	/// <param name="itemObject">GameObject of any item from the item list.</param>
	public int indexOf(GameObject itemObject)
	{
		return itemsList.IndexOf(itemObject);
	}

	/// <summary>
	/// Navigates to Next Item
	/// </summary>
	public void gotoNextItem()
	{
		if (CurrentItem == maximumBoundIndex && isBounded) return;
		if (_currentItemIndex >= itemsList.Count-1 || _isMoving) 
			return;

		for (int i=0; i<itemsList.Count; i++)
		{
			_isMoving = true;
			if (orientation == MenuOrientation.Horizontal)
				iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x",itemsList[i].transform.position.x -itemOffset.x, "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
			else if (orientation == MenuOrientation.Vertical)
				iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"y",itemsList[i].transform.position.y -itemOffset.y, "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
			else if (orientation == MenuOrientation.Custom)
				iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x", itemsList[i].transform.position.x - itemOffset.x, "y",itemsList[i].transform.position.y -itemOffset.y, "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
		}
		_currentItemIndex++;
		sortOrderOfItems();
	}

	/// <summary>
	/// Navigates to Back Item
	/// </summary>
	public void gotoBackItem()
	{
		if (CurrentItem == minimumBoundIndex && isBounded) return;

		if (_currentItemIndex <= 0 || _isMoving)
			return;
		
		for (int i=0; i<itemsList.Count; i++)
		{
			_isMoving = true;
			if(orientation == MenuOrientation.Horizontal)
				iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x",itemsList[i].transform.position.x + itemOffset.x, "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
			else if (orientation == MenuOrientation.Vertical)
				iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"y",itemsList[i].transform.position.y + itemOffset.y, "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
			else if (orientation == MenuOrientation.Custom)
				iTween.MoveTo(itemsList[i], iTween.Hash("time", animationTime,"x", itemsList[i].transform.position.x + itemOffset.x, "y",itemsList[i].transform.position.y +itemOffset.y, "easeType", easeType, "oncomplete", "moveComplete", "onCompleteTarget", gameObject));
		}
		_currentItemIndex--;
		sortOrderOfItems();
	}

	/// <summary>
	/// Sort order of items for better look.
	/// </summary>
	public void sortOrderOfItems()
	{
		for (int i=CurrentItem-1; i>=0; i--)
		{
			itemsList[i].GetComponent<Renderer>().sortingOrder = i-CurrentItem;
			//itemsList[i].GetComponent<ClickTouchScript>().enabled = true;
		}
		for (int i=itemsList.Count-1; i>CurrentItem; i--)
		{
			itemsList[i].GetComponent<Renderer>().sortingOrder = CurrentItem-i;
			//itemsList[i].GetComponent<ClickTouchScript>().enabled = true;
		}
		itemsList[CurrentItem].GetComponent<Renderer>().sortingOrder = 0;
		//itemsList[CurrentItem].GetComponent<ClickTouchScript>().enabled = false;
	}

	/// <summary>
	/// Dispatches Any Item's Click. This is used to auto-click on items.
	/// </summary>
	public void dispatchCurrentItemClick(int itemIndex, GameObject itemObject)
	{
		if (OnItemClicked != null)
			OnItemClicked(itemIndex, itemObject);
	}

	void moveComplete()
	{
		_isMoving = false;
		itemsList[CurrentItem].GetComponent<Renderer>().sortingOrder = itemsList.Count-1;
	}
}
