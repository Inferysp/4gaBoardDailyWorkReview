import react from 'react';

export default function DownBar({ authorId, lastChange, dueDate, updatedbyId }) {
    var style = "min-w-30 scheme-light";
    function btnEvent()
    {
        alert("test");
    }

    return (
        <div className="downbar">
            <div className={`${style} flex-1`}>
                {authorId = null ? <p>author</p> : authorId}
            </div>
            <div className={`${style} flex-4`}>
                {dueDate = null ? <p>due date</p> : dueDate }
            </div>
            <div className={`${style} flex-1`}>
                {lastChange = null ? <p>updated by</p> : ( new Date(lastChange).toLocaleString() )}
            </div>
            <div className="w-20">
                <button className="button" onClick={btnEvent}>Test</button>
            </div>
        </div>
    )
}
