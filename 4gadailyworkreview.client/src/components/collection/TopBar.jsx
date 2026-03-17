import react from 'react';

export default function TopBar({ boardId, listId, timer }) {
    var style = "w-min-45 scheme-dark";

    return (
        <div className="topbar">
            <div className={`${style}`}>
                <p>Projekt</p>
            </div>
            <div className={`${style}`}>
                <p>Board: {boardId}</p>
            </div>
            <div className={`${style}`}>
                <p>List: {listId}</p>
            </div>
            <div className={`w-min-24 justify-self-end`}>
                <p>Timer: {timer != null ? timer : "brak wpisu"}</p>
            </div>
        </div>
    )
}
