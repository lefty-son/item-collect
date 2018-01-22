using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private enum MOVE_STATE {
        IDLE, LEFT, RIGHT
    }

    [SerializeField]
    private MOVE_STATE STATE;

    private void Awake()
    {
        STATE = MOVE_STATE.IDLE;
        StartCoroutine(Move());
    }

    private IEnumerator Move(){
        STATE = MOVE_STATE.LEFT;
        while(true){
            var r = Random.Range(1, 3);
            var y = Random.Range(0.675f, 1.5f);
            var t = 0f;
            var position = transform.position;
            yield return new WaitForSeconds(r);
            if (STATE == MOVE_STATE.LEFT)
            {
                var x = Random.Range(-1.5f, -0.5f);
                while (t <= 2f)
                {
                    t += Time.deltaTime;
                    yield return null;
                    transform.position = Vector3.Lerp(position, new Vector3(x, y, 0), t / 2f);
                }

                STATE = MOVE_STATE.RIGHT;

            }
            else
            {
                var x = Random.Range(0.5f, 1.5f);
                while (t <= 2f)
                {
                    t += Time.deltaTime;
                    yield return null;
                    transform.position = Vector3.Lerp(position, new Vector3(x, y, 0), t / 2f);
                }
                STATE = MOVE_STATE.LEFT;
            }
        }
    }
}
