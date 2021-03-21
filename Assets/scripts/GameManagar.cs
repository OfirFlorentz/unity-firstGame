using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject avatar;
    GameObject curr_avatar = null;
    int speed = 5;
    Vector3 scale = new Vector3(0.01f, 0.01f, 0.01f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Cast a ray from screen point
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Save the info
            RaycastHit hit;
            // You successfully hi
            if (Physics.Raycast(ray, out hit) && hit.transform.parent.CompareTag("terrain"))
            {
                Vector3 pos = hit.point + (Vector3.up * 0f);
                if (curr_avatar != null)
                {    
                    curr_avatar.GetComponent<Outline>().enabled = false;
                    curr_avatar.GetComponent<Move>().enabled = false;
                    curr_avatar.GetComponent<Rigidbody>().isKinematic = true;

                }
                curr_avatar = Instantiate(avatar, pos, Quaternion.identity);
                curr_avatar.GetComponent<Outline>().enabled = true;
                curr_avatar.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    

        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from screen point
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Save the info
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.CompareTag("fox"))
            {
                if (curr_avatar != null)
                {
                    curr_avatar.GetComponent<Outline>().enabled = false;
                    curr_avatar.GetComponent<Move>().enabled = false;
                    curr_avatar.GetComponent<Rigidbody>().isKinematic = true;
                }
                curr_avatar = hit.transform.gameObject;
                curr_avatar.GetComponent<Outline>().enabled = true;
                curr_avatar.GetComponent<Rigidbody>().isKinematic = false;

            }
        }

        if (Input.GetKeyDown("right") && curr_avatar != null)
        {
            curr_avatar.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        }

        if (Input.GetKeyDown("left") && curr_avatar != null)
        {
            curr_avatar.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
        }

        if (Input.GetKey("up") && curr_avatar != null)
        {
            curr_avatar.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey("down") && curr_avatar != null)
        {
            curr_avatar.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.Delete) && curr_avatar != null)
        {
            Destroy(curr_avatar);
            curr_avatar = null;
        }

        
        if (Input.GetKey("t") && curr_avatar != null)
        {
            curr_avatar.transform.localScale += scale;
        }

        if (Input.GetKey("r") && curr_avatar != null)
        {
            curr_avatar.transform.localScale -= scale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && curr_avatar != null)
        {
            if (curr_avatar.GetComponent<Move>().enabled == false)
                curr_avatar.GetComponent<Move>().enabled = true;
            else
                curr_avatar.GetComponent<Move>().enabled = false;
        }
    }
}
