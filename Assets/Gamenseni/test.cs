using UnityEngine.UI;
using System.Linq;

private Toggle toggle1;
private ToggleGroup toggleGroup1;

void Start()
{
		toggle1 = GetComponent<Toggle>();
		toggleGroup1 = GetComponent<ToggleGroup>();
}
　
void Update()
{
		Debug.Log("Update:" + toggleGroup1.AnyTogglesOn());  // いずれかのトグルがオンになっているか
		if (toggleGroup1.AnyTogglesOn())
		{
				toggle1 = toggleGroup1.ActiveToggles().FirstOrDefault();  // チェックが付いているトグルを取得
				Debug.Log("toggle:"toggle1.name); 
		}
}

// このメソッドをOn Click()に指定するとボタンを押したときにメソッドを呼び出す
public void OnClick()
{
		Debug.Log(toggle1.isOn);  // トグルの状態
}
