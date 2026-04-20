import CardBox from './CardBox.jsx';

export default function CollectionCards({ data }) {

    return (
        <div className="listcontainer">
            <ul>
                {data.map(item => (
                    <li key={item.id}>
                        <CardBox
                            cardName={item.name}
                            description={item.description}
                            timer={item.timer}
                            boardId={item.boardId}
                            listId={item.listId}
                            authorId={item.updatedById}
                            lastChange={item.updatedAt}
                            createDate={item.createdAt}
                        />
                    </li>
                ))}
            </ul>
        </div>
    );
}