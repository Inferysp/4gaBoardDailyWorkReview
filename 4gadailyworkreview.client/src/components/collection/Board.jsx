import { useEffect, useState } from "react";
export default function Board({ style, board, loading, error }) {

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div className={`${style}`}>
            <p>Board: {board != null ? board.name : "Empty"}</p>
        </div>

    )
}