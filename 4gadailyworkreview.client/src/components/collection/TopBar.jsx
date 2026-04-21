import { useState, useEffect } from "react";
import List from './List.jsx';
import Project from './Project.jsx';
import Timer from './Timer.jsx';
import Board from './Board.jsx';

export default function TopBar({ boardId, listId, timer }) {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);

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
        <div className="topBar">
            <Project projectid={data.projectId} />
            <Board loading={loading} error={error} board={data} />
            <List loading={loading} error={error} listid={listId} />
            <Timer loading={loading} error={error} timer={timer} />
        </div>
    )
}
