using UnityEngine;
using System.Collections;

public class PlayerStateWaterGate : MonoBehaviour {
    enum State {
        INITIAL = 0,
        BOOK_FOUND,
        FLOPPY_FOUND,
        DONE
    };

    State state = State.INITIAL;

    void nextStep()
    {
        Debug.Log("Next step!");
        state = (State)((int)state + 1);
        
        switch(state) {
            case State.BOOK_FOUND:
                // Open the offices
                Destroy(GameObject.Find("door_unlock_office_1"));
                Destroy(GameObject.Find("door_unlock_office_2"));
                break;
            case State.FLOPPY_FOUND:
                // Open the exit
                Destroy(GameObject.Find("door_unlock_exit"));
                break;
            default:
                break;
        }
    }
}
