import react from 'react';

export default function DownBar() {
    var style = "min-w-30 scheme-light";

    function btnEvent()
    {
        alert("test");
    }

    return (
        <div className="downbar">
            <div className={`${style} flex-1`}>
                <p>Author</p>
            </div>
            <div className={`${style} flex-4`}>
                <p>due Date</p>
            </div>
            <div className={`${style} flex-1`}>
                <p>Last Date Time</p>
            </div>
            <div className="w-20">
                <button className="button" onClick={btnEvent}>Test</button>
            </div>
        </div>
    )
}
