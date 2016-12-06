#pragma strict
var doorObject:GameObject;
var openedDoor:boolean;
function Start () {
	openedDoor=true;
}

function Update () {
	
}

//function OnTriggerEnter(other:Collider){
//	if (openedDoor){
//		doorObject.GetComponent.<Animation>().Play();
//		openedDoor=false;
//		Debug.Log("open");
//	}
//}

function OnTriggerStay(other:Collider){
    var nums : GameObject;
    nums =  GameObject.Find("numbers");
    var txt : TextMesh = nums.GetComponent(TextMesh) as TextMesh;
    if (openedDoor){
        if ((parseInt(txt.text) == 1912)) {
            doorObject.GetComponent.<Animation>().Play();
            openedDoor=false;
            Debug.Log("open");
        }
	}
}