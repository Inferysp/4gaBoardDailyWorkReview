import { useEffect, useState } from "react";
export default function Board({ board, loading, error }) {

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div className="boardTopBar flex gap-x-1">
            <p>Board: </p><p className="strongText italicText">{board != null ? board.name : "Empty"}</p>
        </div>

    )
}