import React, { useState } from "react";
import CardDetails  from "../CardDetailsTest/CardDetails.jsx"

function Btn({ cardId }) {
    const [trigger, setTrigger] = useState(false);
    function clickHandler()
    {
        if (trigger) {
            setTrigger(false)
        } else {
            setTrigger(true)
        }
    }
    return (
        <div>
            <button onClick={clickHandler}>Przycisk: {trigger ? 'klikniêto' : 'odklikniêto'}</button>
            {/*{trigger && <CardDetails cardId={cardId} />}*/}
            {trigger ? <CardDetails cardId={cardId} /> : <CardDetails cardId ="1701608556567988009" />}
        </div>
    )
}

export default Btn;