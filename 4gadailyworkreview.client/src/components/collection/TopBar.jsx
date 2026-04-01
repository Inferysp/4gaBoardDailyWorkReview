import { useState, useEffect } from "react";
import List from './List.jsx';
import Project from './Project.jsx';
export default function TopBar({ boardId, listId, timer }) {
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);
    const [data, setData] = useState(null);
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

    var boardName = "Empty";
    useEffect(() => {
        const fetchResults = async () => {
            try {
                const response = await fetch(`api/board/${boardId}`);
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                const result = await response.json();
                setData(result);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        };

        fetchResults();
    }, [boardId]);

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div className="topbar">
            <div className={`${style}`}>
                <Project style={style} projectid={data.projectId} />
            </div>
            <div className={`${style}`}>
                <p>Board: {data != null ? data.name : "Empty"}</p>
            </div>
            <List style={style} listid={listId} />
            <div className={`w-min-24 justify-self-end`}>
                <p>Timer: {timer != null ? ( timerr != null ? time : "") : "brak wpisu"}</p>
            </div>
        </div>
    )
}
