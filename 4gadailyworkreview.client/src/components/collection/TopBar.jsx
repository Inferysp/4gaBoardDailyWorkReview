import react from 'react';

export default function TopBar() {
    var style = "w-45 scheme-dark";

    return (
        <div className="topbar">
            <div className={`${style}`}>
                <p>Projekt</p>
            </div>
            <div className={`${style}`}>
                <p>Board</p>
            </div>
            <div className={`${style}`}>
                <p>List</p>
            </div>
            <div className={`w-24 justify-self-end`}>
                <p>Timer</p>
            </div>
        </div>
    )
}
