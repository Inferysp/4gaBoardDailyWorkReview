import react from 'react'
import TopBar from "./TopBar.jsx";
import BoxCenter from "./BoxCenter.jsx";
import DownBar from "./DownBar.jsx";

export default function CardBox({ cardName, description, timer, boardId, listId, authorId, lastChange, createDate, dueDate, updatedbyId }) {

    return (
        <div className="cardbox">
            <TopBar boardId={boardId} listId={listId} timer={timer} />
            <BoxCenter cardName={cardName} description={description} />
            <DownBar
                authorId={authorId}
                lastChange={lastChange}
                dueDate={dueDate}
                createDate={createDate} />
        </div>
    )
}