import React, { useEffect, useState } from 'react';
import CardWorkReview from './CardWorkReview/CardWorkReview.jsx';
import { format } from "date-fns";
import CardBox from './CardBox.jsx';

function CollectionCardsYsp({ day }) {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const formatedDay = format(day, "yyyy-MM-dd");

    useEffect(() => {
        const fetchResults = async () => {
            try {
                const response = await fetch(`/cards/day/${formatedDay}`);
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                const result = await response.json();
                console.log(result);
                setData(result);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        };

        fetchResults();
    }, [day]); // Dodano day jako dependency

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

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

export default CollectionCardsYsp;