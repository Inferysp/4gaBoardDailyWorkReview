export default function TopBar({ boardId, listId, timer }) {
    let style = "w-min-45 scheme-dark";
    let timerr
    let time;

    if (timer != null) {
        timerr = JSON.parse(timer);

        let hours = Math.floor(timerr.total / 3600);
        let minutes = Math.floor((timerr.total % 3600) / 60);
        let seconds = timerr.total % 60;

        let hour = hours < 10 ? `0${hours}:` : `${hours}:`;
        let minute = minutes < 10 ? `0${minutes}:` : `${minutes}:`;
        let second = seconds < 10 ? `0${seconds}` : `${seconds}`;
        time = `${hour.toString()}${minute.toString()}${second.toString()}`;
    }

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
                <p>Timer: {timer != null ? ( timerr != null ? time : "") : "brak wpisu"}</p>
            </div>
        </div>
    )
}
