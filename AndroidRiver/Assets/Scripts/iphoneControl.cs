using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iphoneControl : MonoBehaviour
{

	Quaternion origin;

    // Start is called before the first frame update
    void Start()
    {
		origin = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			//向上转
				transform.Rotate(Time.deltaTime * 30, 0, 0);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//向下转
				transform.Rotate(-Time.deltaTime * 30, 0, 0);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			//向左转
				transform.Rotate(0, -Time.deltaTime * 30, 0);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//向右转
			transform.Rotate(0, Time.deltaTime * 30, 0);
		}
        if (Input.GetKey(KeyCode.Space))
            {
			transform.rotation = origin;
            }
		//*/

	}
}
